using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Domain.Service.Impl;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Simple;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// The user courses controller class
    /// </summary>
    /// <seealso cref="ControllerBase"/>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "admin")]
    public class UserCoursesController(IUserCourseService userCourseService) : ControllerBase
    {
        // GET: api/UserCourses
        /// <summary>
        /// Gets the user course
        /// </summary>
        /// <returns>A task containing an action result of i enumerable user course simple dto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCourseSimpleDto>>> GetUser_Course()
        {
            return Ok(await userCourseService.GetAllUsersWithCourses());
        }

        // GET: api/UserCourses/5
        /// <summary>
        /// Gets the user course using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing an action result of i enumerable user course complex dto</returns>
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<IEnumerable<UserCourseComplexDto>>> GetUserCourse(int userId)
        {
            return Ok(await userCourseService.GetByAllByUserId(userId));
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
