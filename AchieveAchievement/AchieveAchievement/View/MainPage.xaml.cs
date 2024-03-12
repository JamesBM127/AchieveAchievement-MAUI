using AchieveAchievement.View;
using AchieveAchievement.ViewModel;

namespace AchieveAchievement.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            DesktopLogin();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage), false);
        }

        private async void DesktopLogin()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage), false);
        }
    }

}
