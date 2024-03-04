using AchieveAchievementLibrary.Entity;
using Microsoft.EntityFrameworkCore;

namespace AchieveAchievementLibrary.Data.DataSettings
{
    public static class PlayerFriendDataSettings
    {
        public static void PlayerModelBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerFriend>(model =>
            {
                model.ToTable("Player Friend");

                model.HasKey(x => new {x.Player1Id, x.Player2Id});

                model.Property(x => x.Player1)
                     .HasColumnName("Player1")
                     .IsRequired();

                model.Property(x => x.Player2)
                     .HasColumnName("Player2")
                     .IsRequired();

                model.HasOne(X => X.Player1)
                     .WithMany(xf => xf.Friends)
                     .HasForeignKey(x => x.Player1Id)
                     .OnDelete(DeleteBehavior.Cascade);

                model.HasOne(X => X.Player2)
                     .WithMany()
                     .HasForeignKey(x => x.Player2Id)
                     .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
