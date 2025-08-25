using Microsoft.EntityFrameworkCore;
using ToDo.API.Infrastructure.Entities;

namespace ToDo.API.Infrastructure;

public class AppDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; } = default!;
    
    public virtual DbSet<UserTask> Tasks { get; set; } = default!;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}