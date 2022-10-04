using SMS.Grades.Domain.Abstractions.Repositories;
using SMS.Grades.Domain.Models;
using SMS.Grades.Repository.Context;

namespace SMS.Grades.Repository;

public class GradeRepository : BaseRepository<Grade>, IGradeRepository
{
    public GradeRepository(ApplicationDbContext context) : base(context)
    {
    }
}