using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Activities.Domain.Models;

namespace SMS.Activities.Repository.Configuration;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.DeadLine).IsRequired();
        builder.Property(x => x.TeacherId).IsRequired();
        builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
    }
}