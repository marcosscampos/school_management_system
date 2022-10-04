using SMS.Grades.Domain.Abstractions.Settings;

namespace SMS.Grades.Domain.Models;

public class Grade : Entity
{
    public long SubmissionId { get; set; }
    public long TeacherId { get; set; }
    public double Rate { get; set; }
}