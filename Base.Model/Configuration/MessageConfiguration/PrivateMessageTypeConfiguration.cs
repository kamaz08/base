using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using Base.Model.Model.MessageModel;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class PrivateMessageTypeConfiguration : EntityTypeConfiguration<PrivateMessage>
    {
        public PrivateMessageTypeConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Date)
                .IsRequired();

            HasRequired(x => x.FromAppUser)
                .WithMany()
                .HasForeignKey(x => x.FromAppUserId);

            HasRequired(x => x.ToAppUser)
                .WithMany()
                .HasForeignKey(x => x.ToAppUserId)
                .WillCascadeOnDelete(true);

            HasOptional(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId);
        }
    }
}