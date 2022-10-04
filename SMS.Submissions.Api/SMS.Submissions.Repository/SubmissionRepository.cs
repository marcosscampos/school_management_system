using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SMS.Submissions.Domain.Abstractions.Repositories;
using SMS.Submissions.Domain.Models;
using SMS.Submissions.Repository.Context;

namespace SMS.Submissions.Repository;

public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
{
    public SubmissionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Submission>> GetAll(Expression<Func<Submission, bool>> expression) 
        => await Entity.Where(expression).ToListAsync();
}