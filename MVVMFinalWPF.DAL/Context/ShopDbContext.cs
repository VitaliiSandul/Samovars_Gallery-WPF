namespace MVVMFinalWPF.DAL.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopDbContext : DbContext
    {
        public ShopDbContext()
            : base("name=ShopDbContext")
        {
        }

        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Samovar> Samovar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.ManufacturerName)
                .IsUnicode(false);

            modelBuilder.Entity<Samovar>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Samovar>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Samovar>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);
        }
    }
}
