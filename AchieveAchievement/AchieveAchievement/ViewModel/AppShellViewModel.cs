using AchieveAchievement.ViewPage;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveAchievement.ViewModel
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task GoToSettingsAsync()
        {
            await Shell.Current.GoToAsync(nameof(SettingsPage), false);
        }
    }
}
