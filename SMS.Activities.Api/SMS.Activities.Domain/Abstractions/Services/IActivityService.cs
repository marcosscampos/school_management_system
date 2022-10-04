using SMS.Activities.Application.Dto;

namespace SMS.Activities.Domain.Abstractions.Services;

public interface IActivityService
{
    Task<ActivityDto> PublishActivity(ActivityDto dto);
    Task<ActivityDto> GetActivity(long activityId);
    Task<IEnumerable<ActivityDto>> GetAllActivities();
    Task<IEnumerable<SubmissionDto>> GetSubmissions(long activityId);
}