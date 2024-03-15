using AchieveAchievementLibrary.JBMException;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

        #region Navigation
        [RelayCommand]
        protected async Task GoBackAsync()
        {
            try
            {
                AppIsBusy();
                IsBusy = true;

                Page currentPage = Shell.Current.CurrentPage;
                await Shell.Current.GoToAsync("..", true);
                RemovePage(currentPage);
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        protected void RemovePage(Page currentPage)
        {
            Shell.Current.Navigation.RemovePage(currentPage);
        }
        #endregion
    }
}
