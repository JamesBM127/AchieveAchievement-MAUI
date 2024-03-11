using AchieveAchievement.ViewModel;

namespace AchieveAchievement.View;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
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

    private void SignInBtnClicked(object sender, EventArgs e)
    {
        LineSignBtnSelected.SetValue(Grid.ColumnProperty, 0);

    }

    private void SignUpBtnClicked(object sender, EventArgs e)
    {
        LineSignBtnSelected.SetValue(Grid.ColumnProperty, 1);
    }

    private void ForgotPasswordBtnPressed(object sender, EventArgs e)
    {
        ForgotPasswordBtn.BackgroundColor = Color.FromRgb(0, 128, 0);
    }

    private void ForgotPasswordBtnReleased(object sender, EventArgs e)
    {
        ForgotPasswordBtn.BackgroundColor = Color.FromRgb(0, 128, 0).MultiplyAlpha(0f);
    }
}