using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Grades.Domain.Models;

namespace SMS.Grades.Repository.Configuration;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TeacherId).IsRequired();
        builder.Property(x => x.SubmissionId).IsRequired();
        builder.Property(x => x.Rate).IsRequired();
        builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
    }
}