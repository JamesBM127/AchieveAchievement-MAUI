using AchieveAchievement.ViewModel;

namespace AchieveAchievement.View;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _viewModel;

    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    private void ShowHidePassword(object sender, TappedEventArgs e)
    {
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        
        if(PasswordEntry.IsPassword)
            PasswordEye.Source = "closed_eye_w.png";
        else
            PasswordEye.Source = "open_eye_w.png";
    }

    private void SignInBtnSelectionClicked(object sender, EventArgs e)
    {
        LineSignBtnSelected.SetValue(Grid.ColumnProperty, 0);
        SignBtnConfirmed.Text = "LOG IN";
        SignBtnConfirmed.BackgroundColor = Color.FromRgb(0, 128, 0);
    }

    private void SignUpBtnSelectionClicked(object sender, EventArgs e)
    {
        LineSignBtnSelected.SetValue(Grid.ColumnProperty, 1);
        SignBtnConfirmed.Text = "CREATE";
        SignBtnConfirmed.BackgroundColor = Color.FromRgb(85, 0, 255);
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
        if(SignBtnConfirmed.Text == "CREATE")
            await _viewModel.CreateAccountAsync();
        else
            await _viewModel.LogInAAAccountAsync();
    }


    private async void FacebookFrameLoginTapped(object sender, TappedEventArgs e)
    {
        await _viewModel.LogInFacebookAccountAsync();
    }

    private async void GoogleFrameLoginTapped(object sender, TappedEventArgs e)
    {
        await _viewModel.LogInGoogleAccountAsync();
    }
}