using Base.Model.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Base.Model.Configuration
{
    public class OrderCategoryTypeConfiguration : EntityTypeConfiguration<OrderCategory>
    {
        public OrderCategoryTypeConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired();
        }
    }
}