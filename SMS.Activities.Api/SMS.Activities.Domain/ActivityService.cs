using System.Net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SMS.Activities.Application.Dto;
using SMS.Activities.CrossCutting.Exceptions;
using SMS.Activities.Domain.Abstractions.Repositories;
using SMS.Activities.Domain.Abstractions.Services;
using SMS.Activities.Domain.Models;
using SMS.Activities.Domain.Utils;

namespace SMS.Activities.Domain
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        
        public ActivityService(IActivityRepository activityRepository, IConfiguration configuration, HttpClient httpClient)
        {
            _activityRepository = activityRepository;
            _configuration = configuration;
            _httpClient = new HttpClient();
        }
        
        public async Task<ActivityDto> PublishActivity(ActivityDto dto)
        {
            var entityCreated = await _activityRepository.Add(dto.ToModel());

            return entityCreated.ToModel();
        }

        public async Task<ActivityDto> GetActivity(long activityId)
        {
            var activity = await _activityRepository.GetById(activityId);
            if (activity is null)
                throw new NotFoundException($"Activity not found with id #{activityId}");
            
            return activity.ToModel();
        }

        public async Task<IEnumerable<ActivityDto>> GetAllActivities()
        {
            var activities = await _activityRepository.GetAll();

            return activities.ToModelList();
        }

        public async Task<IEnumerable<SubmissionDto>> GetSubmissions(long activityId)
        {
            _httpClient.BaseAddress = new Uri(_configuration["Submissions:Url"]);
            _httpClient.Timeout = TimeSpan.FromMilliseconds(double.Parse(_configuration["Submissions:Timeout"]));

            var response = await _httpClient.GetAsync(_configuration["Submissions:Endpoint"] + $"?ActivityId={activityId}");
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new NotFoundException($"Submission not found with id #{activityId}.");
            
            var submissions = JsonConvert.DeserializeObject<List<Submission>>(await response.Content.ReadAsStringAsync());

            return submissions.ToModelList();
        }
    }
}