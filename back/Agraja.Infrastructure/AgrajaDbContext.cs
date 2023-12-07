using Agraja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agraja.Infrastructure
{
    public class AgrajaDbContext : DbContext
    {

        public DbSet<Box> Boxes { get; set; }
        public DbSet<Agro> Agros { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BoxxProduct> BoxxProducts { get; set; }
        public DbSet<AgroxProduct> AgroxProducts { get; set;}
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Conexión con la bd
            optionsBuilder.UseSqlServer("Server = DESKTOP-NR70D4R\\SQLEXPRESS;User Id=sa;Password=Agraja123; Database = AgrajaDb; Trusted_Connection = True;Encrypt=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Si se borra el registro en la tabla 'madre' que también se borre en la tabla de relación
            modelBuilder.Entity<AgroxProduct>()
                .HasOne(x => x.Agro)
                .WithMany()
                .HasForeignKey(x => x.AgroId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<AgroxProduct>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BoxxProduct>()
                .HasOne(x => x.Box)
                .WithMany()
                .HasForeignKey(x => x.BoxId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BoxxProduct>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }




    }
}
