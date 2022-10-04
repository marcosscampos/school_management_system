using System.Net;
using Microsoft.AspNetCore.Mvc;
using SMS.Activities.Api.Common.Responses;
using SMS.Activities.Application.Dto;
using SMS.Activities.Domain.Abstractions.Services;

namespace SMS.Activities.Api.v1.Controllers;

[ApiVersion("1.0")]
[Route("/v{version:apiVersion}/activities")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityService _activityService;
    public ActivitiesController(IActivityService activityService) => _activityService = activityService;

    /// <summary>
    /// Get all activities
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Returns all activities</response>
    /// <response code="500">If has an error in database or something else</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<ActivityDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var activities = await _activityService.GetAllActivities();
        return Ok(activities);
    }

    /// <summary>
    /// Get all submissions by activity id
    /// </summary>
    /// <param name="id">activity identifier</param>
    /// <returns></returns>
    /// <response code="200">Returns all activities</response>
    /// <response code="500">If has an error in database or something else</response>
    [HttpGet("{id:long}/submissions")]
    [ProducesResponseType(typeof(List<SubmissionDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAllSubmissions([FromRoute] long id)
    {
        var submissions = await _activityService.GetSubmissions(id);
        return Ok(submissions);
    }

    /// <summary>
    /// Get a activity by ID
    /// </summary>
    /// <param name="id">activity identifier</param>
    /// <returns></returns>
    /// <response code="200">Returns a activity based on id</response>
    /// <response code="500">If has an error in database or something else</response>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(ActivityDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetCategoryById([FromRoute] long id)
    {
        var activity = await _activityService.GetActivity(id);
        return Ok(activity);
    }

    /// <summary>
    /// Create a activity
    /// </summary>
    /// <param name="dto">object for create a Activity</param>
    /// <returns></returns>
    /// <response code="201">Create a new activity</response>
    /// <response code="400">If any property doesn't agree with what is in the json or didn't find any information in the database</response>
    /// <response code="500">If has an error in database or something else</response>
    [HttpPost]
    [ProducesResponseType(typeof(ActivityDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateCategory([FromBody] ActivityDto dto)
    {
        var activity = await _activityService.PublishActivity(dto);
        return StatusCode(StatusCodes.Status201Created, activity);
    }
}