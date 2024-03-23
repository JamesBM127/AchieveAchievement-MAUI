using AchieveAchievement.Enum;
using AchieveAchievement.ViewModel;

namespace AchieveAchievement.ViewPage;

public partial class SettingsPage : ContentPage
{
    private readonly SettingsViewModel _viewModel;

	public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        _viewModel = viewModel;
	}

    #region Menu
    private void ProfileBtnClicked(object sender, EventArgs e)
    {
        SetAllMenuBtnUncliked();
        SetMenuBtnClicked(ref ProfileView, ref ProfileMenuBtn, Color.FromRgb(76, 76, 76));
        _viewModel.SettingsMenu = SettingsMenu.Profile;
    }

    private void AccountBtnClicked(object sender, EventArgs e)
    {
        SetAllMenuBtnUncliked();
        SetMenuBtnClicked(ref AccountView, ref AccountMenuBtn, Color.FromRgb(76, 76, 76));
        _viewModel.SettingsMenu = SettingsMenu.Account;
    }

    private void ContactBtnClicked(object sender, EventArgs e)
    {
        SetAllMenuBtnUncliked();
        SetMenuBtnClicked(ref ContactView, ref ContactMenuBtn, Color.FromRgb(76, 76, 76));
        _viewModel.SettingsMenu = SettingsMenu.Contact;
    }

    #endregion

    #region Settings
    private void SetAllMenuBtnUncliked()
	{
        ProfileMenuBtn.BackgroundColor =
        ContactMenuBtn.BackgroundColor =
        AccountMenuBtn.BackgroundColor = Color.FromRgba(0, 0, 0, 0);

        SetAllViewsInvisible();
	}

    private void SetAllViewsInvisible()
    {
        ProfileView.IsVisible =
        ContactView.IsVisible =
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