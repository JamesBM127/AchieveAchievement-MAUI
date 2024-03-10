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

    private void SignInBttClicked(object sender, EventArgs e)
    {
        lineSignBttSelected.SetValue(Grid.ColumnProperty, 0);
    }

    private void SignUpBttClicked(object sender, EventArgs e)
    {
        lineSignBttSelected.SetValue(Grid.ColumnProperty, 1);
    }

    private void UpdateBtnColor(bool signInSelecionado)
    {
        Color selectedColor = Color.FromRgb(0, 128, 0);
        Color notSelectedColor = Color.FromRgb(0, 128, 0).MultiplyAlpha(0f); // Using MultiplyAlpha to define transparency

        SignInBtt.BackgroundColor = signInSelecionado ? selectedColor : notSelectedColor;
        SignUpBtt.BackgroundColor = signInSelecionado ? notSelectedColor : selectedColor;
    }

}