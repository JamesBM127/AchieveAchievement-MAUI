using AchieveAchievement.Data;
using AchieveAchievement.Enum;
using AchieveAchievementLibrary.Entity;
using AchieveAchievementLibrary.EntitySettings;
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
    private byte OperationsCount = 0;

    public SettingsViewModel(IAAUoW uow)
        : base(uow)
    {
        GetAccountAndPlayer();
    }

    #region CRUD
    [RelayCommand]
    async Task UpdateSomethingAsync()
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

    private async Task CheckIfContactAddOrUpdate()
    {
        List<JbmEntity.Contact> addContacts = new();
        List<JbmEntity.Contact> updateContacts = new();

        //split who's gonne be added and who's gonne be updated
        foreach (JbmEntity.Contact contact in Contacts)
        {
            if (contact.Id == null)
            {
                addContacts.Add(contact);
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
                        if(contact.Id == itemContact.Id)
                        {
                            updateContacts.Add(contact);
                        }
                    }
                    catch(InvalidCastException ex)
                    {
                    }
                }
            }
        }

        if (addContacts.Count > 0)
        {
            OperationsCount++;
            await CreateContactAsync(addContacts);
        }
        if (updateContacts.Count > 0)
        {
            OperationsCount++;
            await UpdateContactAsync(updateContacts);
        }
    }

    private async Task CreateContactAsync(List<JbmEntity.Contact> addContacts)
    {
        try
        {
            AppIsBusy();
            IsBusy = true;
            
            await _uow.AddAsync(addContacts);
            bool saved = await _uow.CommitAsync(true);
            if (saved)
                await DisplayMessageAfterSaveContact();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task UpdateContactAsync(List<JbmEntity.Contact> updateContacts)
    {
        try
        {
            AppIsBusy();
            IsBusy = true;

            _uow.Update(updateContacts);
            bool saved = await _uow.CommitAsync(true);
            if (saved)
                await DisplayMessageAfterSaveContact();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            IsBusy = false;
        }
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

    private async void GetAccountAndPlayer()
    {
        if (Account == null || string.IsNullOrWhiteSpace(Account.Login))
        {
            Account.Id = new Guid(Preferences.Get("AccId", string.Empty));
            Account = await _uow.GetAsync<Account>(x => x.Id == Account.Id, i => i.Include(p => p.Player));
            Player = Account.Player;
        }
    }

    #endregion

    #region Settings
    [RelayCommand]
    async Task CreateNewContactListElement()
    {
        if(await CanCreateMoreContact())
            Contacts.Add(new());
    }

    [RelayCommand]
    void RemoveContactFromListElement(JbmEntity.Contact contact)
    {
        Contacts.Remove(contact);
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

    private async Task DisplayMessageAfterSaveContact()
    {
        OperationsCount--;
        if (OperationsCount == 0)
        {
            await Shell.Current.DisplayAlert("SUCCESS", "Saved successfully", "Ok");
            OperationsCount = 0;
        }
    }
    #endregion
}
