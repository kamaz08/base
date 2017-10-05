namespace Base.Model.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Base.Model.Model.Test;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Base.Model.Model.User;
    using Base.Model.Model.Location;
    using Base.Model.Model.OrderModel;

    public partial class PracaDorywczaDbContext : IdentityDbContext
    {
        public PracaDorywczaDbContext()
            : base("name=PracaDorywczaDbContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<PersonalData>().HasOptional(x => x.Address);
            modelBuilder.Entity<PersonalData>().HasRequired(x => x.AppUser).WithOptional(x => x.PersonalData).WillCascadeOnDelete(true);
            modelBuilder.Entity<PersonalProfile>().HasRequired(x => x.AppUser).WithOptional(x => x.PersonalProfile).WillCascadeOnDelete(true);
            modelBuilder.Entity<OrderDetail>().HasRequired(x => x.Order).WithOptional(x => x.OrderDetail).WillCascadeOnDelete(true);
            modelBuilder.Entity<Order>().HasRequired(x => x.Employer).WithMany(x => x.Order).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(true);
           // modelBuilder.Entity<AppUserOrderCandidate>().HasKey(x=>x.Order).
           // modelBuilder.Entity<Order>().HasMany(x => x.Candidate).WithMany(x => x.)
            //modelBuilder.Entity<Order>().HasMany(x => x.Customer).WithMany(x => x.);
        }
        //https://stackoverflow.com/questions/7050404/create-code-first-many-to-many-with-additional-fields-in-association-table


        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<TestDb> Test { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<PersonalData> PersonalData { get; set; }
        public DbSet<PersonalProfile> PersonalProfile { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        


        public static PracaDorywczaDbContext Create()
        {
            return new PracaDorywczaDbContext();
        }
    }
}
