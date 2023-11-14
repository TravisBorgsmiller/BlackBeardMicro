using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    // Add other DbSet properties for additional entities

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity relationships, constraints, etc.
        // This method is optional but useful for more advanced configurations.
    }
}
