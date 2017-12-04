using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class PreferenceTypeConfiguration : EntityTypeConfiguration<Preference>
    {
        public PreferenceTypeConfiguration()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.OrderCategoryId);

            HasRequired(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.AppUserId);
        }
    }
}