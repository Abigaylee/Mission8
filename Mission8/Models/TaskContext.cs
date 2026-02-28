using Microsoft.EntityFrameworkCore;

namespace Mission8.Models;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }
// Set up the two separate tables.
    public DbSet<TaskModel> Tasks => Set<TaskModel>();
    public DbSet<Category> Categories => Set<Category>();
    
    // Create them with their relationships. 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasIndex(c => c.CategoryName)
            .IsUnique();

        modelBuilder.Entity<TaskModel>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

