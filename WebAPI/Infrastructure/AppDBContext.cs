using AppDbContext;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Infrastructure;

public class AppDBContext : DbContext
{
    public AppDBContext()
    {

    }

    public AppDBContext(DbContextOptions<MyA2Context> options)
           : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=172.0.0.15;Initial Catalog=ef3;User=jesus;password=jesus1");
        }
    }
    
    public virtual DbSet<Origen> Origenes   { get; set; }
    public virtual DbSet<TiposDeProducto> TipoDeProductos { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }




}

