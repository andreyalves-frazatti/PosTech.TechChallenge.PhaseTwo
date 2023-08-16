using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options)
        : base(options)
    { }

    public required DbSet<News> News { get; set; }

    public required DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<News>()
            .ToTable("News")
            .HasKey(c => c.Id);

        modelBuilder.Entity<User>()
            .ToTable("User")
            .HasKey(c => c.Id);

        base.OnModelCreating(modelBuilder);
    }
}