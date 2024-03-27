using AchieveAchievement.ViewModel;
using AchieveAchievement.ViewPage.PageSettings;

namespace AchieveAchievement.ViewPage;

public partial class LoginMobilePage : ContentPage
{
    private readonly LoginViewModel _viewModel;

    public LoginMobilePage(LoginViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;

        AutoLogin();
    }

    #region TEST 
    private void AutoLogin()
    {
        _viewModel.FakeLogin();
    }
    #endregion

    #region PageLeftSide
    private void ShowHidePassword(object sender, TappedEventArgs e)
    {
        LoginSettings.ShowHidePassword(ref PasswordEntry, ref PasswordEye);
    }

    private void SignInBtnSelectionClicked(object sender, EventArgs e)
    {
        LoginSettings.SignInBtnSelectionClicked(ref LineSignBtnSelected, ref SignBtnConfirmed, ref AccountCreateGrid);

        //Do not erase, uncomment only when login with Google and Facebook are implemented
        //SocialMediaFrame.IsVisible = true;
        //RightBodyLabelText.IsVisible = true;
    }

    private void SignUpBtnSelectionClicked(object sender, EventArgs e)
    {
        LoginSettings.SignUpBtnSelectionClicked(ref LineSignBtnSelected,
                                                ref SignBtnConfirmed,
                                                ref AccountCreateGrid,
                                                ref SocialMediaFrame);
    }

    private void ForgotPasswordBtnPressed(object sender, EventArgs e)
    {
        ForgotPasswordBtn.BackgroundColor = Color.FromRgb(0, 128, 0);
    }

    private async void ForgotPasswordBtnReleased(object sender, EventArgs e)
    {
        ForgotPasswordBtn.BackgroundColor = Color.FromRgb(0, 128, 0).MultiplyAlpha(0f);
        await _viewModel.ForgotPasswordAsync();
    }

    private async void SignBtnConfirmedClicked(object sender, EventArgs e)
    {
        if (SignBtnConfirmed.Text == "CREATE")
            await _viewModel.CreateAAAccountAsync();
        else
            await _viewModel.LogInAAAccountAsync();
    }

    #endregion

    #region PageRightSide
    private async void FacebookFrameLoginTapped(object sender, TappedEventArgs e)
    {
        await _viewModel.LogInFacebookAccountAsync();
    }

    private async void GoogleFrameLoginTapped(object sender, TappedEventArgs e)
    {
        await _viewModel.LogInGoogleAccountAsync();
    }
    #endregion
}