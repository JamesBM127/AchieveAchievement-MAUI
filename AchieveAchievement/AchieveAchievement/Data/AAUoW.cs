using AchieveAchievementLibrary.Data;
using JBMDatabase.UnitOfWork;

namespace AchieveAchievement.Data
{
    public class AAUoW : UoW, IAAUoW
    {
        public AAUoW(AchieveAchievementContext context) : base(context)
        {
        }
    }
}
