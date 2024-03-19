using AchieveAchievement.ViewModel;
using AchieveAchievement.ViewPage;

namespace AchieveAchievement
{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;

            Routing.RegisterRoute(nameof(LoginDesktopPage), typeof(LoginDesktopPage));
            Routing.RegisterRoute(nameof(LoginMobilePage), typeof(LoginMobilePage));
            Routing.RegisterRoute(nameof(InitialPage), typeof(InitialPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        }
    }
}
