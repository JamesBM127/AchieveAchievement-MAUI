using AchieveAchievementLibrary.Entity;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AchieveAchievement.ViewModel;

[QueryProperty(nameof(Player), "Player")]
[QueryProperty(nameof(Account), "Account")]
public partial class InitialViewModel : BaseViewModel
{
    [ObservableProperty]
    Player player = new();
    [ObservableProperty]
    Account account = new();

}
