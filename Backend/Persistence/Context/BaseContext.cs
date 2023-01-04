using Backend.Core.Domain;
using Backend.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Context;
public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

    public DbSet<Product> Products => this.Set<Product>();
    public DbSet<Category> Categories => this.Set<Category>();
    public DbSet<AppUser> AppUsers => this.Set<AppUser>();
    public DbSet<AppRole> AppRoles => this.Set<AppRole>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
