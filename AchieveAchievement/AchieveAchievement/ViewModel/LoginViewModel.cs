using AchieveAchievement.Data;
using AchieveAchievement.Resources.Languages;
using AchieveAchievement.ViewPage;
using AchieveAchievementLibrary.Entity;
using AchieveAchievementLibrary.EntitySettings;
using AchieveAchievementLibrary.JBMException;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Platform;
using System.Globalization;

namespace AchieveAchievement.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string inputPassword;
        [ObservableProperty]
        public Account account = new();
        [ObservableProperty]
        public Player player = new() { BirthDate = DateTime.Now};

        public LocalizationResourceManager LocalizationResourceManager => LocalizationResourceManager.Instance;

        private readonly IAAUoW _uow;

        public LoginViewModel(IAAUoW uow)
        {
            _uow = uow;
        }

        #region CRUD
        public async Task CreateAAAccountAsync()
        {
            try
            {
                AppIsBusy();
                IsBusy = true;

                bool added = false;

                if (Player.IsValid())
                {
                    added = await _uow.AddAsync(Player);

                    if (added)
                    {
                        Account.PlayerId = Player.Id;
                        (Account.Salt, Account.HashedPassword) = AccountSettings.GetSaltAndHashPassword(InputPassword);

                        if (Account.IsValid())
                        {
                            added = await _uow.AddAsync(Account);
                            Player.AccountId = Account.Id;
                        }

                        bool saved = await _uow.CommitAsync(added);

                        if (saved)
                            await Shell.Current.DisplayAlert("Success", "CREATED!", "Ok");
                        else
                            throw new NotAddedException(typeof(Account).Name, NotAddedException.defaultMessage);
                    }
                    else
                    {
                        throw new NotAddedException(typeof(Player).Name, NotAddedException.defaultMessage);
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
            Account? accountFromDb;
            try
            {
                AppIsBusy();
                IsBusy = true;

                accountFromDb = await _uow.GetAsync<Account>(x => x.Login == Account.Login);

                if (AccountSettings.AuthLogin(InputPassword, accountFromDb.Salt, accountFromDb.HashedPassword))
                {
                    SuccessLogin();
                }
                else
                {
                    FailLogin();
                }
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("ERROR", ex.Message, "Ok");
            }
            finally
            {
                accountFromDb = null;
                IsBusy = false;
            }
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

        private async void SuccessLogin()
        {
            Page currentPage = Shell.Current.CurrentPage;
            await Shell.Current.GoToAsync(nameof(InitialPage), true);
            RemovePage(currentPage);
        }

        //DELETE
        [RelayCommand]
        public async void FakeLogin()
        {
            var switchToCulture = AppResources.Culture.TwoLetterISOLanguageName
                .Equals("pt", StringComparison.InvariantCultureIgnoreCase)?
                new CultureInfo("en-US") : new CultureInfo("pt-BR");

            LocalizationResourceManager.Instance.SetCulture(switchToCulture);

#if DEBUG
            //SuccessLogin();
#endif
        }

        private async void FailLogin()
        {
            await Shell.Current.DisplayAlert("Fail", "Login or Password invalid!", "Ok");
        }
        #endregion
    }
}
