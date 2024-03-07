using AchieveAchievementLibrary.Data.DataSettings;
using AchieveAchievementLibrary.Entity;
using Microsoft.EntityFrameworkCore;

namespace AchieveAchievementLibrary.Data
{
    public class AchieveAchievementContext : DbContext
    {
        public AchieveAchievementContext(DbContextOptions<AchieveAchievementContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AccountModelBuilder();
            modelBuilder.PlayerModelBuilder();
            modelBuilder.AchievementModelBuilder();
            modelBuilder.ContactModelBuilder();
            modelBuilder.GameModelBuilder();
            modelBuilder.PlayerFriendModelBuilder();
        }
    }
}
