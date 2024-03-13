using AchieveAchievementLibrary.JBMException;
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

        protected void AppIsBusy()
        {
            if (IsBusy)
                throw new IsBusyException();
        }
    }
}
