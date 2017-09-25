namespace Base.Model.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Base.Model.Model.Test;

    public partial class PracaDorywczaDbContext : DbContext
    {
        public PracaDorywczaDbContext()
            : base("name=PracaDorywczaDbContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //aby w³¹czyæ kaskade to modelNuilder.Entity<Test>().HasRequried(x=>x.Test).WithMany(x=>x.InnaTabela).HasForeignKJe(x=>x.testId).WillCascadeDeletetrue



        }

        public DbSet<TestDb> Test { get; set; }
    }
}
