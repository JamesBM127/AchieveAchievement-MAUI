using AchieveAchievement.View;
using AchieveAchievement.ViewModel;

namespace AchieveAchievement
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

        }
    }
}
