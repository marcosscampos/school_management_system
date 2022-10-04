using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMS.Submissions.Domain.Models;

namespace SMS.Submissions.Repository.Configuration;

public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
{
    public void Configure(EntityTypeBuilder<Submission> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.ActivityId).IsRequired();
        builder.Property(x => x.GradeId).IsRequired();
        builder.Property(x => x.StudentId).IsRequired();
        builder.Property(x => x.ClassRoomId).IsRequired();
        builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
    }
}