using Base.Model.Model.OrderModel;
using System.Data.Entity.ModelConfiguration;

namespace Base.Model.Configuration
{
    public class OrderTypeConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderTypeConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);

            Property(x => x.Rate)
                .IsRequired()
                .HasMaxLength(64);

            Property(x => x.CreatedDate)
                .IsRequired();

            Property(x => x.ResultDate)
                .IsRequired();

            Property(x => x.WorkDate)
                .IsRequired();

            HasRequired(x => x.Employer)
                .WithMany()
                .HasForeignKey(x => x.EmployerId)
                .WillCascadeOnDelete();

            HasOptional(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId);

            HasMany(x => x.Customer)
                .WithRequired(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            HasOptional(x => x.OrderDetail)
                .WithRequired(x => x.Order);

            HasMany(x => x.PrivateMessage)
                .WithOptional(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);
        }
    }
}