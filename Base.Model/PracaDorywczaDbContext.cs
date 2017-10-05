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

            modelBuilder.Entity<Address>()
                .HasRequired(x => x.AppUser)
                .WithOptional(x => x.Address)
                .WillCascadeOnDelete(true);
            //aby w³¹czyæ kaskade to modelNuilder.Entity<Test>().HasRequried(x=>x.Test).WithMany(x=>x.InnaTabela).HasForeignKJe(x=>x.testId).WillCascadeDeletetrue
        }



        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<TestDb> Test { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<PersonalData> PersonalData {get;set;}

        public static PracaDorywczaDbContext Create()
        {
            return new PracaDorywczaDbContext();
        }
    }
}
