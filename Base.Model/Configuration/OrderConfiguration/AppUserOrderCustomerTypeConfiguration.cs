using Base.Model.Model.OrderModel;
using System.Data.Entity.ModelConfiguration;

namespace Base.Model.Configuration
{
    public class AppUserOrderCustomerTypeConfiguration : EntityTypeConfiguration<AppUserOrderCustomer>
    {
        public AppUserOrderCustomerTypeConfiguration()
        {
            HasKey(x => new { x.AppUserId, x.OrderId });

            HasRequired(x => x.Order)
                .WithMany(x => x.Customer)
                .HasForeignKey(x => x.OrderId);

            HasRequired(x => x.AppUser)
                .WithMany(x => x.OrderCustomer)
                .HasForeignKey(x => x.AppUserId);
        }
    }
}