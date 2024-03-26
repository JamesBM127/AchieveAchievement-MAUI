using AchieveAchievement.Data;
using AchieveAchievement.Enum;
using AchieveAchievementLibrary.Entity;
using AchieveAchievementLibrary.EntitySettings;
using Azure;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using JbmEntity = AchieveAchievementLibrary.Entity;

namespace AchieveAchievement.ViewModel;

[QueryProperty(nameof(Player), "Player")]
public partial class SettingsViewModel : BaseViewModel
{
    [ObservableProperty]
    Account account = new();
    [ObservableProperty]
    Player player = new();

    [ObservableProperty]
    string oldPassword, newPassword;

    public ObservableCollection<JbmEntity.Contact> Contacts { get; set; } = new();
    public SettingsMenu SettingsMenu { get; set; } = SettingsMenu.Profile;

    //Array positions
    //0-Create(Added) | 1-Update(Modified) | 2-Delete
    private EntityState[] CrudOperationsMade = new EntityState[3] { EntityState.Unchanged, EntityState.Unchanged, EntityState.Unchanged };

    public SettingsViewModel(IAAUoW uow)
        : base(uow)
    {
        GetAccountAndPlayerAsync();
        GetContactsAsync();
    }

    #region CRUD
    [RelayCommand]
    async Task UpdateSomethingAsync()
    {
        bool confirm = await Shell.Current.DisplayAlert("Confirm?", "", "Confirm", "Cancel");
        if (confirm)
        {
            switch (SettingsMenu)
            {
                case SettingsMenu.Account:
                    break;

                case SettingsMenu.Profile:
                    await UpdatePlayerAsync();
                    break;

                case SettingsMenu.Contact:
                    await CheckIfContactAddOrUpdate();
                    break;
            }
        }
    }

    private async Task CheckIfContactAddOrUpdate()
    {
        List<JbmEntity.Contact> addContacts = new();
        List<JbmEntity.Contact> updateContacts = new();

        //split who's gonne be added and who's gonne be updated
        foreach (JbmEntity.Contact contact in Contacts)
        {
            if (contact.IsValid())
            {
                if (contact.Id == null || contact.Id == Guid.Empty)
                {
                    if (contact.PlayerId == null || contact.PlayerId == Guid.Empty)
                    {
                        if (Player.Id == null ||
                            Player.Id == Guid.Empty)
                        {
                            string? playerStringId = Preferences.Get("PlayerId", null);
                            Player = await _uow.GetAsync<Player>(new Guid(playerStringId));
                        }
                    }
                    contact.PlayerId = Player.Id;
                    addContacts.Add(contact);
                    CrudOperationsMade[0] = EntityState.Added;
                }
                else
                {
                    //Modifie Nuggets to use a expression to get the track
                    var modifiedEntries = _uow.Track();
                    modifiedEntries = modifiedEntries.Where(x => x.State == EntityState.Modified);

                    foreach (var item in modifiedEntries)
                    {
                        try
                        {
                            JbmEntity.Contact itemContact = (JbmEntity.Contact)item.Entity;
                            if (contact.Id == itemContact.Id)
                            {
                                updateContacts.Add(contact);
                                CrudOperationsMade[1] = EntityState.Modified;
                            }
                        }
                        catch (InvalidCastException ex)
                        {
                        }
                    }
                }
            }
        }

        //foreach (EntityState operation in CrudOperationsMade)
        //{
        //    switch (operation)
        //    {
        //        case EntityState.Added:
        //            await CreateContactAsync(addContacts);
        //            break;
        //        case EntityState.Modified:
        //            UpdateContact(updateContacts);
        //            break;
        //    }
        //}

        for (int i = 0; i < CrudOperationsMade.Length; i++)
        {
            switch (CrudOperationsMade[i])
            {
                case EntityState.Added:
                    await CreateContactAsync(addContacts);
                    break;
                case EntityState.Modified:
                    UpdateContact(updateContacts);
                    break;
            }
        }

        bool commit = CrudOperationsMade.Any(x => x != EntityState.Unchanged);
        if(commit)
            await CommitContactAsync(commit);
    }

    private async Task CreateContactAsync(List<JbmEntity.Contact> addContacts)
    {
        await _uow.AddAsync(addContacts);
    }

    private void UpdateContact(List<JbmEntity.Contact> updateContacts)
    {
        _uow.Update(updateContacts);
    }

    private async Task UpdatePlayerAsync()
    {
        try
        {
            AppIsBusy();
            IsBusy = true;

            bool updated = _uow.Update(Player);
            if (await _uow.CommitAsync(updated))
                await Shell.Current.DisplayAlert("Success", "Profile updated successfully!", "OK");
            else
                await Shell.Current.DisplayAlert("Fail", "Something went wrong!", "OK");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Fail", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task<bool> DeleteContactAsync(JbmEntity.Contact contact)
    {
        bool deleted = false;
        try
        {
            AppIsBusy();
            IsBusy = true;

            deleted = _uow.Delete(contact);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Fail", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

        return deleted;
    }

    private async Task CommitContactAsync(bool commit)
    {
        bool saved = await _uow.CommitAsync(commit);
        if (saved)
        {
            await Shell.Current.DisplayAlert("Success", "Saved successfully", "Ok");

            for (int i = 0; i < CrudOperationsMade.Length; i++)
            {
                CrudOperationsMade[i] = EntityState.Unchanged;
            }
        }
    }

    private async void GetAccountAndPlayerAsync()
    {
        if (Account == null || string.IsNullOrWhiteSpace(Account.Login))
        {
            Account.Id = new Guid(Preferences.Get("AccId", string.Empty));
            Account = await _uow.GetAsync<Account>(x => x.Id == Account.Id, i => i.Include(p => p.Player));
            Player = Account.Player;
        }
    }

    private async void GetContactsAsync()
    {
        Contacts.Clear();

        string? playerStringId = Preferences.Get("PlayerId", Guid.Empty.ToString());
        Guid playerId = new Guid(playerStringId);

        IReadOnlyCollection<JbmEntity.Contact> contactsFromDb = await _uow.ListAsync<JbmEntity.Contact>(x => x.PlayerId == playerId);

        foreach (JbmEntity.Contact item in contactsFromDb)
        {
            Contacts.Add(item);
        }
    }
    #endregion

    #region Settings
    [RelayCommand]
    async Task CreateNewContactListElement()
    {
        if (await CanCreateMoreContact())
            Contacts.Add(new());
    }

    [RelayCommand]
    async Task RemoveContactFromListElement(JbmEntity.Contact contact)
    {
        if (await DeleteContactAsync(contact))
        {
            Contacts.Remove(contact);
            CrudOperationsMade[2] = EntityState.Deleted;
        }
    }

    private async Task<bool> CanCreateMoreContact()
    {
        JbmEntity.Contact? lastContact = Contacts.LastOrDefault();
        byte maxContacts = 5;

        if (lastContact == null)
        {
            return true;
        }
        else if (Contacts.Count >= maxContacts)
        {
            await Shell.Current.DisplayAlert("Contact Limit", $"Max contact limit: {maxContacts}", "Ok");
            return false;
        }
        else if (lastContact.IsValid())
        {
            return true;
        }
        else
        {
            await Shell.Current.DisplayAlert("Invalid Contact", "Last contact is invalid", "Ok");
            return false;
        }
    }

    #endregion
}
