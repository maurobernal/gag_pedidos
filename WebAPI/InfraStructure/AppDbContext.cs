using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Entities;

namespace WebAPI.InfraStructure;

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
            optionsBuilder.UseSqlServer("Data Source=172.0.0.15;Initial Catalog=EF1;User=maxi;password=maxi1");
        }
    }

    public virtual EntityEntry Update(object entity)
    {
        
        var result = base.Update(entity);

        return result;
    }
    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<TableBase>())
            if (entry.State == EntityState.Added)
                entry.Entity.Active = true;
         
        var result = base.SaveChanges();

        return result;
    }

    public virtual DbSet<Origin> Origins { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductType> ProductsTypes { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderDetail> OrdersDetails { get; set; }
}

