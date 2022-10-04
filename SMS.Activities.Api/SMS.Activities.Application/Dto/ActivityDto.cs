namespace SMS.Activities.Application.Dto;

public class ActivityDto
{
    public long Id { get; set; }
    public string Content { get; set; }
    public long TeacherId { get; set; }
    public DateTime DeadLine { get; set; }
    public DateTime CreatedAt { get; set; }
}