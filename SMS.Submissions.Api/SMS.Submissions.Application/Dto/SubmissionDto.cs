namespace SMS.Submissions.Application.Dto;

public class SubmissionDto
{
    public string Content { get; set; }
    public long StudentId { get; set; }
    public long ClassRoomId { get; set; }
    public long ActivityId { get; set; }
    public long GradeId { get; set; }
}