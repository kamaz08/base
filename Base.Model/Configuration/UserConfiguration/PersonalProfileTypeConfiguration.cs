using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class PersonalProfileTypeConfiguration : EntityTypeConfiguration<PersonalProfile>
    {
        public PersonalProfileTypeConfiguration()
        {
            HasKey(x => x.Id);
            HasRequired(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.AppUserId);
        }
    }
}