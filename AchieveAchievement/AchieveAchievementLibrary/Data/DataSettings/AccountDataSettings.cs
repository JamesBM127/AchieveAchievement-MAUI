using AchieveAchievementLibrary.Entity;
using JBMDatabase.Data.DataSettings;
using Microsoft.EntityFrameworkCore;

namespace AchieveAchievementLibrary.Data.DataSettings
{
    public static class AccountDataSettings
    {
        public static void AccountModelBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityModelBuilder<Account>();

            modelBuilder.Entity<Account>(model =>
            {
                model.ToTable("Account");

                model.Property(x => x.Login)
                     .HasColumnName("Login")
                     .IsRequired();

                model.Property(x => x.BirthDate)
                     .HasColumnName("Birth Date")
                     .IsRequired();

                model.Property(x => x.Email)
                     .HasColumnName("Email")
                     .IsRequired();

                model.Property(x => x.Password)
                     .HasColumnName("Password")
                     .IsRequired();

                model.HasOne(x => x.Player)
                     .WithOne(x => x.Account)
                     .HasForeignKey<Account>(x => x.PlayerId)
                     .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
