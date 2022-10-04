using SMS.Submissions.Application.Dto;
using SMS.Submissions.CrossCutting.Exceptions;
using SMS.Submissions.Domain.Abstractions.Repositories;
using SMS.Submissions.Domain.Abstractions.Services;
using SMS.Submissions.Domain.Query;
using SMS.Submissions.Domain.Utils;

namespace SMS.Submissions.Domain
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepository;
        
        public SubmissionService(ISubmissionRepository submissionRepository)
        {
            _submissionRepository = submissionRepository;
        }

        public async Task CreateSubmission(SubmissionDto dto) => await _submissionRepository.Add(dto.ToModel());

        public async Task<IEnumerable<SubmissionDto>> GetAllSubmissions(SubmissionQuery query)
        {
            var activities = await _submissionRepository.GetAll(query.BuildFilter());

            return activities.ToModelList();
        }

        public async Task<SubmissionDto> GetSubmission(long id)
        {
            var submission = await _submissionRepository.GetById(id);
            if (submission is null)
                throw new NotFoundException($"Submission not found with id #{id}");

            return submission.ToModel();
        }
    }
}