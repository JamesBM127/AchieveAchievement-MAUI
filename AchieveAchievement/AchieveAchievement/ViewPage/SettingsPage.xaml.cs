using AchieveAchievement.ViewModel;

namespace AchieveAchievement.ViewPage;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    #region Menu
    private void ProfileBtnClicked(object sender, EventArgs e)
    {
        SetAllMenuBtnUncliked();
        SetMenuBtnClicked(ref ProfileView, ref ProfileMenuBtn, Color.FromRgb(76, 76, 76));
    }

    private void AccountBtnClicked(object sender, EventArgs e)
    {
        SetAllMenuBtnUncliked();
        SetMenuBtnClicked(ref AccountView, ref AccountMenuBtn, Color.FromRgb(76, 76, 76));
    }

    #endregion

    #region Settings
    private void SetAllMenuBtnUncliked()
	{
        ProfileMenuBtn.BackgroundColor =
        AccountMenuBtn.BackgroundColor = Color.FromRgba(0, 0, 0, 0);

        SetAllViewsInvisible();
	}

    private void SetAllViewsInvisible()
    {
        ProfileView.IsVisible =
        AccountView.IsVisible = false;
    }

    private void SetMenuBtnClicked<TView>(ref TView view,
                                   ref Button button,
                                   Color color) where TView : ContentView
    {
        view.IsVisible = true;
        button.BackgroundColor = color;
    }
    #endregion
}