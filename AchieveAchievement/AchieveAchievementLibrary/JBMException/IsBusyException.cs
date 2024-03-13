using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveAchievementLibrary.JBMException
{
    public class IsBusyException : Exception
    {
        public IsBusyException() : base("Another operation is running, try again if the problem persist, restart the app!") { }

        public IsBusyException(string message) : base(message) { }
        
        public IsBusyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
