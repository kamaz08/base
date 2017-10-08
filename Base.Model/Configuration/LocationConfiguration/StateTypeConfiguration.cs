using Base.Model.Model.Location;
using System.Data.Entity.ModelConfiguration;

namespace Base.Model.Configuration
{
    public class StateTypeConfiguration : EntityTypeConfiguration<State>
    {
        public StateTypeConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}