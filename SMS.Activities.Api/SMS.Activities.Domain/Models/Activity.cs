using SMS.Activities.Domain.Abstractions.Settings;

namespace SMS.Activities.Domain.Models;

public class Activity : Entity
{
    public Activity(string content, int teacherId, DateTime deadLine)
    {
        Content = content;
        TeacherId = teacherId;
        DeadLine = deadLine;
    }

    public Activity() { }

    public string Content { get; set; }
    public long TeacherId { get; set; }
    public DateTime DeadLine { get; set; }
}