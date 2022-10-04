using SMS.Submissions.Application.Dto;
using SMS.Submissions.Domain.Models;

namespace SMS.Submissions.Domain.Utils;

public static class Converter
{
    public static IEnumerable<SubmissionDto> ToModelList(this IEnumerable<Submission> gradeList)
        => gradeList.Select(item => new SubmissionDto
        {
            Content = item.Content,
            ActivityId = item.ActivityId,
            ClassRoomId = item.ClassRoomId,
            GradeId = item.GradeId,
            StudentId = item.StudentId
        });

    public static SubmissionDto ToModel(this Submission item)
        => new()
        {
            Content = item.Content,
            ActivityId = item.ActivityId,
            ClassRoomId = item.ClassRoomId,
            GradeId = item.GradeId,
            StudentId = item.StudentId
        };
    
    public static IEnumerable<Submission> ToModelList(this IEnumerable<SubmissionDto> gradeList)
        => gradeList.Select(item => new Submission
        {
            Content = item.Content,
            ActivityId = item.ActivityId,
            ClassRoomId = item.ClassRoomId,
            GradeId = item.GradeId,
            StudentId = item.StudentId
        });

    public static Submission ToModel(this SubmissionDto item)
        => new()
        {
            Content = item.Content,
            ActivityId = item.ActivityId,
            ClassRoomId = item.ClassRoomId,
            GradeId = item.GradeId,
            StudentId = item.StudentId,
        };
    
    public static IEnumerable<Grade> ToModelList(this IEnumerable<GradeDto> gradeList)
        => gradeList.Select(item => new Grade
        {
            SubmissionId = item.SubmissionId,
            Rate = item.Rate,
            TeacherId = item.TeacherId
        });

    public static Grade ToModel(this GradeDto grade)
        => new()
        {
            SubmissionId = grade.SubmissionId,
            Rate = grade.Rate,
            TeacherId = grade.TeacherId
        };
}