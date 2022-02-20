using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Data;

public class AssignmentContext : DbContext
{
    public AssignmentContext(DbContextOptions<AssignmentContext> options) 
        : base(options) 
    {
    }
    public DbSet<Assignment> Assignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>()
            .Property(a => a.IsDone)
            .HasDefaultValue(false);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=TaskDb;User Id=postgres;Password=nimda;");
}