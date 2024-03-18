using AchieveAchievement.Data;
using AchieveAchievement.Resources.Languages;
using AchieveAchievementLibrary.JBMException;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;

namespace AchieveAchievement.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy, isRefreshing;

        protected readonly IAAUoW? _uow;

        public BaseViewModel(IAAUoW uow)
        {
            _uow = uow;
        }

        public BaseViewModel() { }

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

        #region Settings
        protected void ChangeCulture(string culture)
        {
            CultureInfo switchToCulture = AppResources.Culture.TwoLetterISOLanguageName
                .Equals("pt", StringComparison.InvariantCultureIgnoreCase) ?
                new CultureInfo("en-US") : new CultureInfo("pt-BR");

            LocalizationResourceManager.Instance.SetCulture(switchToCulture);
            //LocalizationResourceManager.Instance.SetCulture(new CultureInfo(culture));
        }

        [RelayCommand]
        public void TESTE()
        {
            ChangeCulture("pt-br");
        }
        #endregion
    }
}
