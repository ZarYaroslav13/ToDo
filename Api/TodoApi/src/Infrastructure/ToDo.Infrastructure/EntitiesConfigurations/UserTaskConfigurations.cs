using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.EntitiesConfigurations;

public class UserTaskConfigurations : IEntityTypeConfiguration<UserTask>
{
    public void Configure(EntityTypeBuilder<UserTask> builder)
    {
        builder.HasData(DbSeeder.UsersTasks);
        
        builder
            .HasOne(u => u.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(u => u.UserId);
    }
}