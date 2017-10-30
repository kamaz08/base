using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class AppUserTypeConfiguration : EntityTypeConfiguration<AppUser>
    {
        public AppUserTypeConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(256);

            HasMany(x => x.UserOrder)
                .WithRequired(x => x.Employer)
                .HasForeignKey(x => x.EmployerId)
                .WillCascadeOnDelete(true);

            HasMany(x => x.OrderCustomer)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId);

            HasMany(x => x.Vote)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId)
                .WillCascadeOnDelete(true);

            HasMany(x => x.Rater)
                .WithRequired(x => x.Rater)
                .HasForeignKey(x => x.RaterId);

            HasMany(x => x.PrivateMessage)
                .WithRequired(x => x.ToAppUser)
                .HasForeignKey(x => x.ToAppUserId)
                .WillCascadeOnDelete(true);

            HasMany(x => x.SendPrivateMessage)
                .WithRequired(x => x.FromAppUser)
                .HasForeignKey(x => x.FromAppUserId);

            HasMany(x => x.AppUserPublicMessage)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId);
        }
    }
}