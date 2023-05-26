using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityFramework.Contexts;

public class ApplicationDbContext:DbContext,IApplicationDbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DbSet<Order> orders, DbSet<Product> products):base(options)
    {
        Orders = orders;
        Products = products;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      

        base.OnModelCreating(modelBuilder);
    }
}

