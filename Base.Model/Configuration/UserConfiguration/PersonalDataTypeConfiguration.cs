using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class PersonalDataTypeConfiguration : EntityTypeConfiguration<PersonalData>
    {
        public PersonalDataTypeConfiguration()
        {
            HasKey(x => x.id);
            Property(x => x.FirstName)
                .HasMaxLength(32);

            Property(x => x.LastName)
                .HasMaxLength(32);

            Property(x => x.Pesel)
                .HasMaxLength(11);

            Property(x => x.PhoneNumber)
               .HasMaxLength(16);

            Property(x => x.DateCreated)
                .IsRequired();

            Property(x => x.DateModifield)
                .IsRequired();

            HasRequired(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.AppUserId);

            HasOptional(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId)
                .WillCascadeOnDelete(true);

        }
    }
}