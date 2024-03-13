using JBMDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveAchievementLibrary.JBMException
{
    public class NotAddedException : Exception
    {
        public static string defaultMessage = " not added on database!";

        public NotAddedException() : 
            base(defaultMessage) { }

        public NotAddedException(string message) :
            base(message) { }

        public NotAddedException(string entityName, string message) :
            base(string.Concat(entityName, message)) { }
    }
}
