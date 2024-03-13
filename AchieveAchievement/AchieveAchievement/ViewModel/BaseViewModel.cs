using CommunityToolkit.Mvvm.ComponentModel;

namespace AchieveAchievement.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy, isRefreshing;

        public BaseViewModel()
        {
        }
    }
}
