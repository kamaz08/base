using Base.Model.Model.Location;
using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class AddressTypeConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressTypeConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Street)
                .HasMaxLength(64);

            Property(x => x.ZipCode)
                .HasMaxLength(8);

            Property(x => x.HouseNumber)
                .HasMaxLength(8);

            Property(x => x.FlatNumber)
                .HasMaxLength(8);

            HasOptional(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId);

            HasOptional(x => x.State)
                .WithMany()
                .HasForeignKey(x => x.StateId);
        }
    }
}