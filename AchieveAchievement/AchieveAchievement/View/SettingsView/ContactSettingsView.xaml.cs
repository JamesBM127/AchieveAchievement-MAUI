
using AchieveAchievement.ViewModel;

namespace AchieveAchievement.View.SettingsView;

public partial class ContactSettingsView : ContentView
{
	private readonly SettingsViewModel _viewModel;

	public ContactSettingsView(SettingsViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
	}

    private void AddContactSettingsBtn(object sender, EventArgs e)
    {

    }
}