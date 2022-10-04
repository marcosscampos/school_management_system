using System.Net;
using Microsoft.AspNetCore.Mvc;
using SMS.Submissions.Api.Common.Responses;
using SMS.Submissions.Application.Dto;
using SMS.Submissions.Domain.Abstractions.Services;
using SMS.Submissions.Domain.Query;

namespace SMS.Submissions.Api.v1.Controllers;

[ApiVersion("1.0")]
[Route("/v{version:apiVersion}/submissions")]
[ApiController]
public class SubmissionsController : ControllerBase
{
    private readonly ISubmissionService _submissionService;
    public SubmissionsController(ISubmissionService submissionService) => _submissionService = submissionService;

    /// <summary>
    /// Get all submissions
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Returns all submissions</response>
    /// <response code="500">If has an error in database or something else</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<SubmissionDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAll([FromQuery] SubmissionQuery query)
    {
        var submissions = await _submissionService.GetAllSubmissions(query);
        return Ok(submissions);
    }
    
    /// <summary>
    /// Get a submission by id
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Returns submission</response>
    /// <response code="500">If has an error in database or something else</response>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(SubmissionDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetById([FromRoute] long id)
    {
        var submission = await _submissionService.GetSubmission(id);
        return Ok(submission);
    }

    /// <summary>
    /// Publish a new submission
    /// </summary>
    /// <param name="dto">object for publish a submission</param>
    /// <returns></returns>
    /// <response code="201">publish a submission</response>
    /// <response code="400">If any property doesn't agree with what is in the json or didn't find any information in the database</response>
    /// <response code="500">If has an error in database or something else</response>
    [HttpPost]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> PublishSubmission([FromBody] SubmissionDto dto)
    {
        await _submissionService.CreateSubmission(dto);
        return StatusCode(StatusCodes.Status201Created, "Submission processed!");
    }
}