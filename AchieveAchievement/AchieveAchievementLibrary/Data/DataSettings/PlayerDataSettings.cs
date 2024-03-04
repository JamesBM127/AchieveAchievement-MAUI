﻿using AchieveAchievementLibrary.Entity;
using JBMDatabase.Data.DataSettings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                     .HasColumnName("Name")
                     .IsRequired();

                model.Property(x => x.BirthDate)
                     .HasColumnName("Birth Date")
                     .IsRequired();

                model.Property(x => x.Email)
                     .HasColumnName("Email")
                     .IsRequired();

                model.Property(x => x.ShowContacts)
                     .HasColumnName("Show Contacts")
                     .IsRequired();

                model.HasMany(x => x.Games);

                model.HasMany(x => x.Contacts)
                     .WithOne(x => x.Player)
                     .HasForeignKey(x => x.Player.Id);
            });
        }
    }
}