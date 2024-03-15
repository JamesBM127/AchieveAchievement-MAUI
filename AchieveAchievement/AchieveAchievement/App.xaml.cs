using AchieveAchievement.ViewModel;

namespace AchieveAchievement
{
    public partial class App : Application
    {
        public App(AppShellViewModel appShellViewModel)
        {
            InitializeComponent();

            MainPage = new AppShell(appShellViewModel);
        }
    }
}
