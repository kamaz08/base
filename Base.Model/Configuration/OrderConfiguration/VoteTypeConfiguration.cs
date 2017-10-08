using Base.Model.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class VoteTypeConfiguration : EntityTypeConfiguration<Vote>
    {
        public VoteTypeConfiguration()
        {
            HasKey(x=>x.Id);

            Property(x => x.Note)
                .IsRequired();

            Property(x => x.VoteDate)
                .IsRequired();

            Property(x => x.OrderName)
                .IsRequired()
                .HasMaxLength(128);

            HasRequired(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.AppUserId);

            HasRequired(x => x.Rater)
                .WithMany()
                .HasForeignKey(x => x.RaterId);
        }
    }
}