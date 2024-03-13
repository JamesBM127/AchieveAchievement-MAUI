using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveAchievementLibrary.JBMException
{
    /// <summary>
    /// Error key [A00001]
    /// The application is busy.
    /// Some operation has started but not finished yet or not finished successfully!
    /// </summary>
    public class IsBusyException : Exception
    {
        public IsBusyException() : base("error [A00001] Another operation is running, try again if the problem persist, restart the app!") { }

        public IsBusyException(string message) : base(message) { }
    }
}
