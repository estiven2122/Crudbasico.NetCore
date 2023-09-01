using CrudNet7Rezor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CrudNet7Rezor.Datos
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext (DbContextOptions<AplicacionDbContext> options): base(options) 
        {
        }

        //poner los modelos
        public DbSet<Producto> Producto { get; set; }
    }
}
