using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Infrastructure;


    public class AppDBContext : DbContext
    {

    public AppDBContext()
    {
            
    }
    public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=172.0.0.15;Initial Catalog=EF2;User=joaquin;password=joaquin1");
        }
    }


    public virtual DbSet<Origen> Origenes { set; get; }
    public virtual DbSet<Producto> Productos { set; get; }
    public virtual DbSet<TipoDeProducto> TipoDeProductos { set; get; }


    public override int SaveChanges()
    {

        foreach (var entry in ChangeTracker.Entries<TablaBase>())
            if (entry.State == EntityState.Added)
                entry.Entity.Habilitado = true;
       var result = base.SaveChanges();

        return result;
    }


}

