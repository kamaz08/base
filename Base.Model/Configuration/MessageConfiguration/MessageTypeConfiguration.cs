using Base.Model.Model.MessageModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class MessageTypeConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageTypeConfiguration()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.PublicMessage)
                .WithMany(x => x.Message)
                .HasForeignKey(x => x.PublicMessageId);

            HasRequired(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.AppUserId);

            Property(x => x.Date)
                .IsRequired();
        }
    }
}