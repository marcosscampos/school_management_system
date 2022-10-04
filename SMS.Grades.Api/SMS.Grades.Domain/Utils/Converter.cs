using SMS.Grades.Application.Dto;
using SMS.Grades.Domain.Models;

namespace SMS.Grades.Domain.Utils;

public static class Converter
{
    public static IEnumerable<GradeDto> ToModelList(this IEnumerable<Grade> gradeList)
        => gradeList.Select(item => new GradeDto
        {
            SubmissionId = item.SubmissionId,
            Rate = item.Rate,
            TeacherId = item.TeacherId
        });

    public static GradeDto ToModel(this Grade grade)
        => new()
        {
            SubmissionId = grade.SubmissionId,
            Rate = grade.Rate,
            TeacherId = grade.TeacherId
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