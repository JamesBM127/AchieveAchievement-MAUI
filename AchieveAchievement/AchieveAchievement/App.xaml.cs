using AchieveAchievement.View;
using AchieveAchievement.ViewModel;

namespace AchieveAchievement
{
    public partial class App : Application
    {
        public App(LoginViewModel viewModel)
        {
            InitializeComponent();

            MainPage = new LoginPage(viewModel);
        }
    }
}
