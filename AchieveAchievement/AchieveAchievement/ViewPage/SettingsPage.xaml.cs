using AchieveAchievement.ViewModel;

namespace AchieveAchievement.ViewPage;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}