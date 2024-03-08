using AchieveAchievementLibrary.Entity;
using JBMDatabase.Business;
using JBMDatabase.UnitOfWork;

namespace AchieveAchievementLibrary.Business
{
    public class AccountBussiness : BaseBusiness
    {
        private readonly IUoW _uow;

        public AccountBussiness(IUoW uow) : base(uow)
        {
            _uow = uow;
        }
    }
}
