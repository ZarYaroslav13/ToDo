using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.API.Infrastructure.Entities;

namespace ToDo.API.Infrastructure.EntitiesConfigurations;

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