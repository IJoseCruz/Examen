using Examen.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examen
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }

        public static void Seed(AppDbContext context)
        {
            if (!context.Productos.Any())
            {
                context.Productos.AddRange(
                    new Productos
                    {
                        Nombre = "Producto 1",
                        Descripcion = "Descripción del Producto 1",
                        Precio = 100.50m,
                        CantidadStock = 10,
                        FechaCreacion = DateTime.Now
                    },
                    new Productos
                    {
                        Nombre = "Producto 2",
                        Descripcion = "Descripción del Producto 2",
                        Precio = 50.75m,
                        CantidadStock = 5,
                        FechaCreacion = DateTime.Now
                    },
                    new Productos
                    {
                        Nombre = "Producto 3",
                        Descripcion = "Descripción del Producto 3",
                        Precio = 25.99m,
                        CantidadStock = 20,
                        FechaCreacion = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
