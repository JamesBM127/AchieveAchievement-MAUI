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
    public static class ContactDataSettings
    {
        public static void ContactModelBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityModelBuilder<Contact>();

            modelBuilder.Entity<Contact>(model =>
            {
                model.ToTable("Contact");

                model.Property(x => x.Link)
                     .IsRequired(false);

                model.Property(x => x.App)
                     .IsRequired(false);

                model.Property(x => x.NameInApp)
                     .IsRequired(false);

                model.Property(x => x.PlayerId)
                     .IsRequired();

                model.HasOne(x => x.Player)
                     .WithMany(x => x.Contacts)
                     .HasForeignKey(x => x.PlayerId);
            });
        }
    }
}
