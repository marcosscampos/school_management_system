using SMS.Submissions.Application.Dto;
using SMS.Submissions.Domain.Query;

namespace SMS.Submissions.Domain.Abstractions.Services;

public interface ISubmissionService
{
    Task CreateSubmission(SubmissionDto dto);
    Task<IEnumerable<SubmissionDto>> GetAllSubmissions(SubmissionQuery query);
    Task<SubmissionDto> GetSubmission(long id);
}