using AchieveAchievementLibrary.Entity;
using JBMDatabase.Data.DataSettings;
using Microsoft.EntityFrameworkCore;

namespace AchieveAchievementLibrary.Data.DataSettings
{
    public static class PlayerDataSettings
    {
        public static void PlayerModelBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityModelBuilder<Player>();

            modelBuilder.Entity<Player>(model =>
            {
                model.ToTable("Player");

                model.Property(x => x.Name)
                     .HasColumnType("varchar(15)")
                     .IsRequired();

                model.Property(x => x.HideContacts)
                     .IsRequired();

                model.Property(x => x.Languages)
                     .IsRequired(false);

                model.Property(x => x.BirthDate)
                     .IsRequired();

                model.HasMany(x => x.Games);

                model.HasMany(x => x.Contacts)
                     .WithOne(x => x.Player)
                     .HasForeignKey(x => x.PlayerId)
                     .OnDelete(DeleteBehavior.Cascade);

                model.HasOne(x => x.Account)
                     .WithOne(x => x.Player)
                     .HasForeignKey<Player>(x => x.AccountId);
            });
        }
    }
}
