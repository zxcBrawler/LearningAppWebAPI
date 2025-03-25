using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Simple;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "admin")]
    public class UserCoursesController(UserCourseService userCourseService) : ControllerBase
    {
        private readonly UserCourseService _userCourseService = userCourseService;

        // GET: api/UserCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCourseSimpleDto>>> GetUser_Course()
        {
            return Ok(await _userCourseService.GetAllUsersWithCourses());
        }

        // GET: api/UserCourses/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserCourseComplexDTO>>> GetUserCourse(int userId)
        {
            return Ok(await _userCourseService.GetByAllByUserId(userId));
        }

        /*
         
         
         [HttpPost]
         public async Task<ActionResult<UserCourse>> PostUserCourse(UserCourse userCourse)
         {}
        
         [HttpPut("{id}")]
         public async Task<IActionResult> PutUserCourse(int id, UserCourse userCourse)
         {}

         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteUserCourse(int id)
         {}
 */
    }
}
