using System.Net;
using Microsoft.AspNetCore.Mvc;
using SMS.Grades.Api.Common.Responses;
using SMS.Grades.Application.Dto;
using SMS.Grades.Domain.Abstractions.Services;

namespace SMS.Grades.Api.v1.Controllers;

[ApiVersion("1.0")]
[Route("/v{version:apiVersion}/grades")]
[ApiController]
public class GradesController : ControllerBase
{
    private readonly IGradeService _gradeService;
    public GradesController(IGradeService gradeService) => _gradeService = gradeService;

    /// <summary>
    /// Get all grades
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Returns all grades</response>
    /// <response code="500">If has an error in database or something else</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<GradeDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var grades = await _gradeService.GetAllGrades();
        return Ok(grades);
    }

    /// <summary>
    /// Publish a grade's activity
    /// </summary>
    /// <param name="dto">object for publish a grade</param>
    /// <returns></returns>
    /// <response code="201">publish a grade</response>
    /// <response code="400">If any property doesn't agree with what is in the json or didn't find any information in the database</response>
    /// <response code="500">If has an error in database or something else</response>
    [HttpPost("publish")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> PublishGrade([FromBody] GradeDto dto)
    {
        await _gradeService.PublishGrade(dto);
        return StatusCode(StatusCodes.Status201Created, "Grade published successfully!");
    }

    /// <summary>
    /// Create a grade's activity
    /// </summary>
    /// <param name="dto">object for publish a grade</param>
    /// <returns></returns>
    /// <response code="201">Create a grade</response>
    /// <response code="400">If any property doesn't agree with what is in the json or didn't find any information in the database</response>
    /// <response code="500">If has an error in database or something else</response>
    [HttpPost()]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(NonSuccessResponse), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateGrade([FromBody] GradeDto dto)
    {
        await _gradeService.Create(dto);
        return StatusCode(StatusCodes.Status201Created, "Grade created successfully!");
    }
}