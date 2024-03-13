using AchieveAchievement.Data;
using AchieveAchievementLibrary.Entity;
using AchieveAchievementLibrary.EntitySettings;
using AchieveAchievementLibrary.JBMException;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JBMDatabase.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveAchievement.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        public Account account = new();
        [ObservableProperty]
        public Player player = new();

        private readonly IAAUoW _uow;

        public LoginViewModel(IAAUoW uow)
        {
            _uow = uow;
        }

        //public LoginViewModel()
        //{

        //}

        #region CRUD
        public async Task CreateAAAccountAsync()
        {
            try
            {
                IsBusy = true;
                AppIsBusy();

                bool added = false;

                if (Player.IsValid())
                {
                    added = await _uow.AddAsync(Player);
                }
                else
                {
                    throw new NotAddedException();
                }

                if (added)
                {
                    Account.PlayerId = Player.Id;

                    if (Account.IsValid())
                    {
                        added = await _uow.AddAsync(Account);
                        Player.AccountId = Account.Id;
                    }

                    bool saved = await _uow.CommitAsync(added);

                    if (saved)
                    {
                        await Shell.Current.DisplayAlert("Success", "CREATED!", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("FAIL", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion

        #region Log In
        public async Task LogInAAAccountAsync()
        {
            await Shell.Current.DisplayAlert("CLICKED", "LOG IN AA Acc!", "OK");
        }

        [RelayCommand]
        public async Task LogInGoogleAccountAsync()
        {
            await Shell.Current.DisplayAlert("CLICKED", "LOG IN Google Acc!", "OK");
        }

        [RelayCommand]
        public async Task LogInFacebookAccountAsync()
        {
            await Shell.Current.DisplayAlert("CLICKED", "LOG IN Facebook Acc!", "OK");
        }

        public async Task ForgotPasswordAsync()
        {
            await Shell.Current.DisplayAlert("CLICKED", "FORGOT PASSWORD!", "OK");
        }

        #endregion
    }
}
