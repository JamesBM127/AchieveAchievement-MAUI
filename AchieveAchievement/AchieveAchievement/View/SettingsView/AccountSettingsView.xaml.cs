namespace AchieveAchievement.View.SettingsView;

public partial class AccountSettingsView : ContentView
{
	private bool passwordChangeIsVisible = false;

	public AccountSettingsView()
	{
		InitializeComponent();
	}

    private void EditPasswordClicked(object sender, EventArgs e)
    {
		passwordChangeIsVisible = !passwordChangeIsVisible;
		PasswordChange.IsVisible = passwordChangeIsVisible;

		if(passwordChangeIsVisible )
		{
			EditPasswordBtn.Text = "Cancel";
			EditPasswordBtn.BackgroundColor = Color.FromRgb(255, 0, 0);
		}
		else
		{
			EditPasswordBtn.Text = "Edit";
            EditPasswordBtn.BackgroundColor = Color.FromRgb(0, 0, 255);
        }
    }
}