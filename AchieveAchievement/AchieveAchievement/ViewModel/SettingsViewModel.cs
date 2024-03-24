using AchieveAchievement.Data;
using AchieveAchievement.Enum;
using AchieveAchievementLibrary.Entity;
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

    [RelayCommand]
    void CreateNewContactListElement()
    {
        Contacts.Add(new());
    }

}
