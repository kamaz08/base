using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class CityPreferenceTypeConfiguration : EntityTypeConfiguration<CityPreference>
    {
        public CityPreferenceTypeConfiguration()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId);

            HasRequired(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.AppUserId);
        }
    }
}