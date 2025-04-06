using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers;

/// <summary>
///     The courses controller class
/// </summary>
/// <seealso cref="ControllerBase" />
[Route("api/[controller]")]
[ApiController]
[ApiExplorerSettings(GroupName = "admin")]
public class CoursesController(CourseService courseService) : BasicController
{
    /// <summary>
    ///     Gets the courses
    /// </summary>
    /// <returns>A task containing an action result of i enumerable course complex dto</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseComplexDto>>> GetCourses()
    {
        return Ok(await courseService.GetAllCoursesAsync());
    }

    /// <summary>
    ///     Gets the course using the specified id
    /// </summary>
    /// <param name="id">The id</param>
    /// <returns>A task containing an action result of course complex dto</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CourseComplexDto>> GetCourse(int id)
    {
        var course = await courseService.GetCourseById(id);
        if (course == null) return NotFound();
        return Ok(course);
    }

    /// <summary>
    ///     Puts the course using the specified id
    /// </summary>
    /// <param name="id">The id</param>
    /// <param name="dto">The dto</param>
    /// <returns>A task containing the action result</returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutCourse(int id, AddCourseRequestDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var isUpdated = await courseService.UpdateCourse(id, dto);
        if (!isUpdated) return NotFound($"Course with id {id} not found");
        return NoContent();
    }

    /// <summary>
    ///     Posts the course using the specified dto
    /// </summary>
    /// <param name="dto">The dto</param>
    /// <returns>A task containing an action result of course simple dto</returns>
    [HttpPost]
    public async Task<ActionResult<CourseSimpleDto>> PostCourse(AddCourseRequestDto dto)
    {
        var result = await courseService.CreateCourse(dto);
        if (result == null) return BadRequest($"Course with name {dto.CourseName} already exists");
        return CreatedAtAction("GetCourse", new { id = result.Id }, result);
    }

    /// <summary>
    ///     Deletes the course using the specified id
    /// </summary>
    /// <param name="id">The id</param>
    /// <returns>A task containing the action result</returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var isDeleted = await courseService.DeleteCourse(id);
        if (!isDeleted) return NotFound($"Course with id {id} not found.");
        return NoContent();
    }

    /*
     - [] Add Lesson to course
     - [] Delete Lesson from course
     */
}