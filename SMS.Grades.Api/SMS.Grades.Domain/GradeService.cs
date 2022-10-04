using Microsoft.Extensions.Configuration;
using SMS.Grades.Application.Dto;
using SMS.Grades.Domain.Abstractions.Repositories;
using SMS.Grades.Domain.Abstractions.Services;
using SMS.Grades.Domain.Utils;
using SMS.Message.Abstractions.Services;
using SMS.Message.Models;

namespace SMS.Grades.Domain
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IConfiguration _configuration;
        private readonly IBusService _busService;

        public GradeService(IGradeRepository gradeRepository, IBusService busService, IConfiguration configuration)
        {
            _gradeRepository = gradeRepository;
            _busService = busService;
            _configuration = configuration;
        }

        public async Task PublishGrade(GradeDto dto)
        {
            var messageQueue = new GradeMessage
            {
                SubmissionId = dto.SubmissionId,
                Rate = dto.Rate,
                TeacherId = dto.TeacherId
            };

            await _busService.SendMessageToQueueAsync(new MessageQueue<GradeMessage>(Guid.NewGuid(), messageQueue), _configuration["MessagesConfiguration:Queues:Grade"]);
        }

        public async Task<IEnumerable<GradeDto>> GetAllGrades()
        {
            var activities = await _gradeRepository.GetAll();

            return activities.ToModelList();
        }

        public async Task Create(GradeDto dto) => await _gradeRepository.Add(dto.ToModel());
    }
}