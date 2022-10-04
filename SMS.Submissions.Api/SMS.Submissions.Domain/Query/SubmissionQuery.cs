using System.Linq.Expressions;
using SMS.Submissions.CrossCutting.Extensions;
using SMS.Submissions.Domain.Models;

namespace SMS.Submissions.Domain.Query;

public class SubmissionQuery
{
    public long? ActivityId { get; set; }

    public Expression<Func<Submission, bool>> BuildFilter()
    {
        Expression<Func<Submission, bool>> result = o => true;

        if (ActivityId is > 0)
        {
            Expression<Func<Submission, bool>> idFilter = s => s.ActivityId == ActivityId;
            result = result.And(idFilter);
        }

        return result;
    }
}