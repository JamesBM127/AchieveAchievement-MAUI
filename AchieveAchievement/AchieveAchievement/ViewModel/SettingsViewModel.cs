using AchieveAchievement.Data;
using AchieveAchievementLibrary.Entity;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveAchievement.ViewModel
{
    public partial class SettingsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Player player = new();

        public SettingsViewModel(IAAUoW uow)
            : base(uow)
        {
        }

        #region CRUD
        [RelayCommand]
        async Task UpdatePlayerAsync()
        {
            try
            {
                AppIsBusy();
                IsBusy = true;

                bool updated = _uow.Update(Player);
                if(await _uow.CommitAsync(updated))
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
        #endregion
    }
}
