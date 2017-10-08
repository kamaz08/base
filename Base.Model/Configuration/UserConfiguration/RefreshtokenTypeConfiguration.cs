using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class RefreshtokenTypeConfiguration : EntityTypeConfiguration<RefreshToken>
    {
        public RefreshtokenTypeConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(32);
            Property(x => x.ProtectedTicket)
                .IsRequired();
        }
    }
}