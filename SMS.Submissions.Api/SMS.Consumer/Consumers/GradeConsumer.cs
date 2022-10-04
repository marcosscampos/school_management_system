using MassTransit;
using MassTransit.Transports.Fabric;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SMS.Message.Models;
using SMS.Submissions.Application.Dto;
using SMS.Submissions.CrossCutting.Exceptions;
using SMS.Submissions.Domain.Models;
using SMS.Submissions.Domain.Utils;
using System.Net;
using System.Text;

namespace SMS.Consumer.Consumers;

public class GradeConsumer : IConsumer<MessageQueue<GradeMessage>>
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public GradeConsumer(IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = new HttpClient();
    }

    public async Task Consume(ConsumeContext<MessageQueue<GradeMessage>> context)
    {
        Console.WriteLine($"Grade Submitted: {context.Message.MessageId}");
        var gradeMessage = context.Message.Entity;

        await Create(new Grade
        {
            SubmissionId = gradeMessage.SubmissionId,
            Rate = gradeMessage.Rate,
            TeacherId = gradeMessage.TeacherId
        });

        await context.Publish(gradeMessage);
    }

    private async Task Create(Grade grade)
    {
        _httpClient.BaseAddress = new Uri(_configuration["Grades:Url"]);
        _httpClient.Timeout = TimeSpan.FromMilliseconds(double.Parse(_configuration["Grades:Timeout"]));

        var json = new StringContent(JsonConvert.SerializeObject(grade), Encoding.UTF8, "application/json");
        var gradeCreated = await _httpClient.PostAsync(_configuration["Grades:Endpoint"], json);

        var response = gradeCreated.EnsureSuccessStatusCode();
        if (response.StatusCode == HttpStatusCode.BadRequest)
            throw new BadRequestException(new Dictionary<string, string> { { "Error", await response.Content.ReadAsStringAsync() } });
    }
}