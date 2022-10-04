using SMS.Activities.Application.Dto;
using SMS.Activities.Domain.Models;

namespace SMS.Activities.Domain.Utils;

public static class Converter
{
    public static IEnumerable<ActivityDto> ToModelList(this IEnumerable<Activity> activityList)
        => activityList.Select(item => new ActivityDto
        {
            Id = item.Id,
            Content = item.Content,
            DeadLine = item.DeadLine,
            CreatedAt = item.CreatedDate,
            TeacherId = item.TeacherId
        });

    public static ActivityDto ToModel(this Activity activity)
        => new()
        {
            Id = activity.Id,
            Content = activity.Content,
            DeadLine = activity.DeadLine,
            CreatedAt = activity.CreatedDate,
            TeacherId = activity.TeacherId
        };

    public static IEnumerable<Activity> ToModelList(this IEnumerable<ActivityDto> activityList)
        => activityList.Select(item => new Activity
        {
            Content = item.Content,
            DeadLine = item.DeadLine,
            TeacherId = item.TeacherId
        });

    public static Activity ToModel(this ActivityDto activity)
        => new()
        {
            Content = activity.Content,
            DeadLine = activity.DeadLine,
            TeacherId = activity.TeacherId,
        };
    
    public static IEnumerable<SubmissionDto> ToModelList(this IEnumerable<Submission> submissions)
        => submissions.Select(item => new SubmissionDto
        {
            Id = item.Id,
            GradeId = item.GradeId,
        });

}