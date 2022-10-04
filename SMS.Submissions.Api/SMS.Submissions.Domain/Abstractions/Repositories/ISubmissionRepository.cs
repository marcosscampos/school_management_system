using System.Linq.Expressions;
using SMS.Submissions.Domain.Models;

namespace SMS.Submissions.Domain.Abstractions.Repositories;

public interface ISubmissionRepository : IBaseRepository<Submission>
{
    Task<IEnumerable<Submission>> GetAll(Expression<Func<Submission, bool>> expression);
}