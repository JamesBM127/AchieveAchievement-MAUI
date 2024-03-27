using AchieveAchievement.ViewModel;

namespace AchieveAchievement.ViewPage;

public partial class FriendsPage : ContentPage
{
	public FriendsPage(FriendsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}