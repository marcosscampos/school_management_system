using SMS.Grades.Application.Dto;

namespace SMS.Grades.Domain.Abstractions.Services;

public interface IGradeService
{
    Task Create(GradeDto dto);
    Task PublishGrade(GradeDto dto);
    Task<IEnumerable<GradeDto>> GetAllGrades();
}