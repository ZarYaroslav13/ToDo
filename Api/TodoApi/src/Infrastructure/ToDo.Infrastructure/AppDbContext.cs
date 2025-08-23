using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;

namespace ToDo.Infrastructure;

public class AppDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; } = null!;
    
    public virtual DbSet<UserTask> Tasks { get; set; } = null!;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}