using Microsoft.EntityFrameworkCore;
using GestionProductos.Domain.Entities;
namespace GestionProductos.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Semilla de usuarios para probar la autenticación
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "admin", Password = "admin123", Role = "Admin" },
                new User { Id = 2, UserName = "alumno", Password = "alumno123", Role = "User" }
            );

            // Algunos productos para que GET no venga vacío
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Teclado", Description = "Teclado mecánico", Price = 45000m, Stock = 10 },
                new Product { Id = 2, Name = "Mouse", Description = "Mouse inalámbrico", Price = 18000m, Stock = 25 },
                new Product { Id = 3, Name = "Monitor", Description = "Monitor 24 pulgadas", Price = 210000m, Stock = 5 }
            );
        }
    }
}
