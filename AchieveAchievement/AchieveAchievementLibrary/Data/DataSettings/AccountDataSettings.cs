﻿using AchieveAchievementLibrary.Entity;
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
                     .HasColumnType("varchar(20)")
                     .IsRequired();

                model.Property(x => x.Email)
                     .IsRequired();

                model.Property(x => x.Salt)
                     .IsRequired();

                model.Property(x => x.HashedPassword)
                     .IsRequired();

                model.Property(x => x.PlayerId)
                     .IsRequired();

                model.HasOne(x => x.Player)
                     .WithOne(x => x.Account)
                     .HasForeignKey<Account>(x => x.PlayerId)
                     .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}