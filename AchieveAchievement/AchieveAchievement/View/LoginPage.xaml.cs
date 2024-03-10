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
}