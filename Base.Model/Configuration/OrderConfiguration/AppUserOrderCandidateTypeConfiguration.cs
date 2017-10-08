using Base.Model.Model.OrderModel;
using System.Data.Entity.ModelConfiguration;

namespace Base.Model.Configuration
{
    public class AppUserOrderCandidateTypeConfiguration : EntityTypeConfiguration<AppUserOrderCandidate>
    {
        public AppUserOrderCandidateTypeConfiguration()
        {
            HasKey(x => new { x.AppUserId, x.OrderId });

            HasRequired(x => x.Order)
                .WithMany(x=>x.Candidate)
                .HasForeignKey(x => x.OrderId);

            HasRequired(x => x.AppUser)
                .WithMany(x=>x.OrderCandidate)
                .HasForeignKey(x => x.AppUserId);
        }
    }
}