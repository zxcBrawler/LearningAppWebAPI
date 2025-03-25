using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "exercises")]
    public class CoursesController(CourseService courseService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseComplexDto>>> GetCourses()
        {

            return Ok(await courseService.GetAllCoursesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseComplexDto>> GetCourse(int id)
        {
            var course = await courseService.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, AddCourseRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isUpdated = await courseService.UpdateCourse(id, dto);

            if (!isUpdated)
            {
                return NotFound($"Course with id {id} not found");
            }

            return NoContent();
        }



        [HttpPost]
        public async Task<ActionResult<CourseSimpleDto>> PostCourse(AddCourseRequestDto dto)
        {
            var result = await courseService.CreateCourse(dto);
            if (result == null)
            {
                return BadRequest($"Course with name {dto.Course_Name} already exists");
            }

            return CreatedAtAction("GetCourse", new { id = result.Id }, result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            bool isDeleted = await courseService.DeleteCourse(id);

            if (!isDeleted)
            {
                return NotFound($"Course with id {id} not found.");
            }

            return NoContent();
        }

        /*
         - [] Add Lesson to course
         - [] Delete Lesson from course
         */
    }
}
