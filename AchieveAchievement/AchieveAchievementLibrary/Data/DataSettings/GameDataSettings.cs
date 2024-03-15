using AchieveAchievementLibrary.Entity;
using JBMDatabase.Data.DataSettings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveAchievementLibrary.Data.DataSettings
{
    public static class GameDataSettings
    {
        public static void GameModelBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityModelBuilder<Game>();

            modelBuilder.Entity<Game>(model =>
            {
                model.ToTable("Game");

                model.Property(x => x.Name)
                     .IsRequired();

                model.Property(x => x.CrossPlataformGameplay)
                     .IsRequired();

                model.Property(x => x.ObtainablePlatinum)
                     .IsRequired();

                model.Property(x => x.HideGame)
                     .IsRequired();

                model.Property(x => x.PlataformsString)
                     .IsRequired();

                model.HasMany(x => x.Achievements)
                     .WithOne(x => x.Game)
                     .HasForeignKey(x => x.GameId);
            });
        }
    }
}
