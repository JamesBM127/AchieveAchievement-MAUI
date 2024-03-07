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
                     .HasColumnName("Name")
                     .IsRequired();

                model.Property(x => x.Description)
                     .HasColumnName("Description")
                     .IsRequired();

                model.Property(x => x.Tutorial)
                     .HasColumnName("Tutorial")
                     .IsRequired();

                model.Property(x => x.IsOnline)
                     .HasColumnName("Is Online")
                     .IsRequired();

                model.Property(x => x.IsSpoiler)
                     .HasColumnName("Is Spoiler")
                     .IsRequired();

                model.Property(x => x.Missable)
                     .HasColumnName("Missable")
                     .IsRequired();

                model.Property(x => x.DifficultyLevel)
                     .HasColumnName("Difficulty Level")
                     .IsRequired();

                model.Property(x => x.FunLevel)
                     .HasColumnName("Fun Level")
                     .IsRequired();

                model.Property(x => x.GameId)
                     .HasColumnName("Game Id")
                     .IsRequired();

                model.HasOne(x => x.Game)
                     .WithMany(x => x.Achievements)
                     .HasForeignKey(x => x.GameId);
            });
        }
    }
}
