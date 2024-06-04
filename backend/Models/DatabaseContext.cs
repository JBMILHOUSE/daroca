using Microsoft.EntityFrameworkCore;

public partial class DatabaseContext : DbContext {

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<Product> Product { get; set; }
    public virtual DbSet<ProductCategory> ProductCategory { get; set; }
    public virtual DbSet<SalesOrder> SalesOrder { get; set; }
    public virtual DbSet<SalesOrderItem> SalesOrderItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
        modelBuilder.Entity<Customer>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.City).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.State).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Latitude).HasPrecision(11, 3).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Longitude).HasPrecision(11, 3).IsRequired();
        modelBuilder.Entity<Customer>().HasMany<SalesOrder>().WithOne().HasForeignKey(e => e.CustomerId);

        modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
        modelBuilder.Entity<Product>().HasKey(p => p.ProductCategoryId);
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();
        modelBuilder.Entity<Product>().HasMany<SalesOrderItem>().WithOne().HasForeignKey(e => e.ProductId);

        modelBuilder.Entity<ProductCategory>().HasKey(p => p.ProductCategoryId);
        modelBuilder.Entity<ProductCategory>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<ProductCategory>().HasMany<Product>().WithOne().HasForeignKey(e => e.ProductCategoryId);

        modelBuilder.Entity<SalesOrder>().HasKey(p => p.OrderId);
        modelBuilder.Entity<SalesOrder>().Property(p => p.CustomerId).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.OrderDate).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.EstimatedDeliveryDate);
        modelBuilder.Entity<SalesOrder>().Property(p => p.Status).HasMaxLength(20).IsRequired();
        modelBuilder.Entity<SalesOrder>().HasMany<SalesOrderItem>().WithOne().HasForeignKey(e => e.OrderId);
        

        modelBuilder.Entity<SalesOrderItem>().HasKey(p => new { p.OrderId, p.ProductId });
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.Quantity).IsRequired();
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();
        // modelBuilder.Entity<Customer>(entity => {entity.HasKey(k => k.Id);});
        OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}