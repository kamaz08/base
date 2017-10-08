using Base.Model.Model.MessageModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class PublicMessageTypeConfiguration : EntityTypeConfiguration<PublicMessage>
    {
        public PublicMessageTypeConfiguration()
        {
            HasKey(x => x.Id);

            HasOptional(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId);

            HasMany(x => x.Message)
                .WithRequired(x => x.PublicMessage)
                .HasForeignKey(x => x.PublicMessageId);

            HasMany(x => x.AppUserPublicMessage)
                .WithRequired(x => x.PublicMessage)
                .HasForeignKey(x => x.PublicMessageId);
        }
    }
}