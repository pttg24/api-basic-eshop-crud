using System;
using BasicEshopCrud.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BasicEshopCrud.Infrastructure;

public partial class BasicEshopCrudContext : DbContext
{
    public BasicEshopCrudContext(DbContextOptions<BasicEshopCrudContext> options) : base(options)
    {
    }

    public virtual DbSet<Customers> Customers { get; set; }
    public virtual DbSet<Orders> Orders { get; set; }
    public virtual DbSet<Products> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customers>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
    }
}
