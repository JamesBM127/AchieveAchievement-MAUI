using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public string login, password;

        public LoginViewModel()
        {
        }

        public async Task LogInAAAccountAsync()
        {
            await Shell.Current.DisplayAlert("CLICKED", "LOG IN AA Acc!", "OK");
        }

        public async Task CreateAccountAsync()
        {
            await Shell.Current.DisplayAlert("CLICKED", "CREATE ACCOUNT!", "OK");
        }
        
        public async Task ForgotPasswordAsync()
        {
            await Shell.Current.DisplayAlert("CLICKED", "FORGOT PASSWORD!", "OK");
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
    }
}
