using SMS.Submissions.Domain.Abstractions.Settings;

namespace SMS.Submissions.Domain.Models;

public class Grade : Entity
{
    public long SubmissionId { get; set; }
    public long TeacherId { get; set; }
    public double Rate { get; set; }
}