namespace Base.Model.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Base.Model.Model.User;
    using Base.Model.Model.Location;
    using Base.Model.Model.OrderModel;
    using Base.Model.Configuration;
    using Base.Model.Model.MessageModel;

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

            AddUserConfiguration(modelBuilder);
            AddAddressConfiguration(modelBuilder);
            AddOrderConfiguration(modelBuilder);
            AddMessageConfiguration(modelBuilder);

        }
       
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<PersonalData> PersonalData { get; set; }
        public DbSet<PersonalProfile> PersonalProfile { get; set; }

        public DbSet<Address> Address { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<AppUserOrderCandidate> OrderCandidate { get; set; }
        public DbSet<AppUserOrderCustomer> OrderCustomer { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Vote> Vote { get; set; }

        public DbSet<PrivateMessage> PrivateMessage { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<AppUserPublicMessage> AppUserPublicMessage { get; set; }
        public DbSet<PublicMessage> PublicMessage { get; set; }

        private void AddUserConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserTypeConfiguration());
            modelBuilder.Configurations.Add(new PersonalDataTypeConfiguration());
            modelBuilder.Configurations.Add(new PersonalProfileTypeConfiguration());
            modelBuilder.Configurations.Add(new RefreshtokenTypeConfiguration());
        }

        private void AddAddressConfiguration( DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressTypeConfiguration());
            modelBuilder.Configurations.Add(new CityTypeConfiguration());
            modelBuilder.Configurations.Add(new StateTypeConfiguration());
        }

        private void AddOrderConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrderTypeConfiguration());
            modelBuilder.Configurations.Add(new AppUserOrderCandidateTypeConfiguration());
            modelBuilder.Configurations.Add(new AppUserOrderCustomerTypeConfiguration());
        }

        private void AddMessageConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PrivateMessageTypeConfiguration());
            modelBuilder.Configurations.Add(new PublicMessageTypeConfiguration());
            modelBuilder.Configurations.Add(new AppUserPublicMessageTypeConfiguration());
            modelBuilder.Configurations.Add(new MessageTypeConfiguration());
        }



        public static PracaDorywczaDbContext Create()
        {
            return new PracaDorywczaDbContext();
        }
    }
}
