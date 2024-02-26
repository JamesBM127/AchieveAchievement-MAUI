using JBMDatabase.Business;
using JBMDatabase.UnitOfWork;

namespace AchieveAchievementLibrary.Business
{
    public class AchieveAchievementBussiness : BaseBusiness
    {
        public AchieveAchievementBussiness(IUoW repository) : base(repository)
        {
        }
    }
}
