using Base.Model.Model.MessageModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class AppUserPublicMessageTypeConfiguration : EntityTypeConfiguration<AppUserPublicMessage>
    {
        public AppUserPublicMessageTypeConfiguration()
        {
            HasKey(x => new { x.AppUserId, x.PublicMessageId });

            HasRequired(x => x.AppUser)
                .WithMany(x=>x.AppUserPublicMessage)
                .HasForeignKey(x => x.AppUserId);

            HasRequired(x => x.PublicMessage)
                .WithMany(x=>x.AppUserPublicMessage)
                .HasForeignKey(x => x.PublicMessageId);
        }
    }
}