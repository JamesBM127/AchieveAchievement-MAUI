using AchieveAchievement.ViewModel;

namespace AchieveAchievement.ViewPage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //DesktopLogin();
            MobileLogin();
            //FakeLogin();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(LoginDesktopPage), false);
        }

        private async void DesktopLogin()
        {
            await Shell.Current.GoToAsync(nameof(LoginDesktopPage), false);
        }

        private async void MobileLogin()
        {
            await Shell.Current.GoToAsync(nameof(LoginMobilePage), false);
        }

        private async void FakeLogin()
        {
            await Shell.Current.GoToAsync(nameof(InitialPage), false);
        }
    }

}
