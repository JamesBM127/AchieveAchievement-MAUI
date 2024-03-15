using AchieveAchievementLibrary.Entity;
using JBMDatabase.Data.DataSettings;
using Microsoft.EntityFrameworkCore;

namespace AchieveAchievementLibrary.Data.DataSettings
{
    public static class AchievementDataSettings
    {
        public static void AchievementModelBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityModelBuilder<Achievement>();

            modelBuilder.Entity<Achievement>(model =>
            {
                model.ToTable("Achievement");

                model.Property(x => x.Name)
                     .IsRequired();

                model.Property(x => x.Description)
                     .IsRequired();

                model.Property(x => x.Tutorial)
                     .IsRequired();

                model.Property(x => x.IsOnline)
                     .IsRequired();

                model.Property(x => x.IsSpoiler)
                     .IsRequired();

                model.Property(x => x.Missable)
                     .IsRequired();

                model.Property(x => x.DifficultyLevel)
                     .IsRequired();

                model.Property(x => x.FunLevel)
                     .IsRequired();

                model.Property(x => x.GameId)
                     .IsRequired();

                model.HasOne(x => x.Game)
                     .WithMany(x => x.Achievements)
                     .HasForeignKey(x => x.GameId);
            });
        }
    }
}
