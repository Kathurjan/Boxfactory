using Microsoft.EntityFrameworkCore;
using Entities;
namespace Infrastructure;

public class BoxDbContext : DbContext
{
    public BoxDbContext(DbContextOptions<BoxDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boxes>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd();
    }
    public DbSet<Boxes> BoxesTable { get; set; }

}