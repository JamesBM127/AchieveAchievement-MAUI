using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveAchievement.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy, isRefreshing;

        public BaseViewModel()
        {
        }
    }
}
