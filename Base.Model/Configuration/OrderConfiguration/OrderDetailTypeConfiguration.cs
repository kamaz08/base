using Base.Model.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class OrderDetailTypeConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailTypeConfiguration()
        {
            HasKey(x => x.OrderId);

            HasRequired(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId)
                .WillCascadeOnDelete(true);
        }
    }
}