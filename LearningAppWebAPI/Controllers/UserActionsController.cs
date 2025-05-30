using System.Security.Claims;
using LearningAppWebAPI.Domain.Facade;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// Controller handling all user-specific actions and operations
    /// </summary>
    /// <remarks>
    /// Requires authenticated access for all endpoints.
    /// Manages user courses, dictionaries, profile data, and related actions.
    /// </remarks>
    /// <param name="userActionsFacade">Facade service handling user action business logic</param>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "users")]
    [ApiController]
    public class UserActionsController(IUserActionsFacade userActionsFacade) : BasicController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            var profile = await userActionsFacade.GetUserProfileAsync(UserId);
            return StatusCode(profile.StatusCode, profile.IsSuccess ? profile.Value : profile.ErrorMessage);
        }
        /// <summary>
        /// Retrieves all courses associated with the current authenticated user
        /// </summary>
        /// <returns>List of user courses</returns>
        /// <response code="200">Successfully retrieved user courses</response>
        /// <response code="401">Unauthorized access attempt</response>
        /// <response code="404">No courses found for user</response>
        [HttpGet]
        public async Task<IActionResult> GetUserCourses()
        {
            var courses = await userActionsFacade.GetUserCourses(UserId);
            return StatusCode(courses.StatusCode, courses.IsSuccess ? courses.Value : courses.ErrorMessage);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpGet("{courseId:long}")]
        public async Task<IActionResult> GetUserCourse(long courseId)
        {
            var courses = await userActionsFacade.GetUserCourse(UserId, courseId);
            return StatusCode(courses.StatusCode, courses.IsSuccess ? courses.Value : courses.ErrorMessage);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOtherCourses()
        {
            var courses = await userActionsFacade.GetOtherCourses(UserId);
            return StatusCode(courses.StatusCode, courses.IsSuccess ? courses.Value : courses.ErrorMessage);
        }
        
        /// <summary>
        /// Retrieves all dictionaries belonging to the current authenticated user
        /// </summary>
        /// <returns>List of user dictionaries</returns>
        /// <response code="200">Successfully retrieved user dictionaries</response>
        /// <response code="401">Unauthorized access attempt</response>
        /// <response code="404">No dictionaries found for user</response>
        [HttpGet]
        public async Task<IActionResult> GetUserDictionaries()
        {
            var dictionaries = await userActionsFacade.GetUserDictionaries(UserId);
            return StatusCode(dictionaries.StatusCode, dictionaries.IsSuccess ? dictionaries.Value : dictionaries.ErrorMessage);
        }

        /// <summary>
        /// This endpoint triggers refreshToken method in Desktop App when opening it
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult LaunchApp()
        {
            return Ok();
        }
        
        /// <summary>
        /// Retrieves a specific dictionary by ID for the current authenticated user
        /// </summary>
        /// <param name="dictionaryId">ID of the dictionary to retrieve</param>
        /// <returns>Requested dictionary details</returns>
        /// <response code="200">Successfully retrieved dictionary</response>
        /// <response code="401">Unauthorized access attempt</response>
        /// <response code="404">Dictionary not found</response>
        [HttpGet("{dictionaryId:int}")]
        public async Task<IActionResult> GetUserDictionaryById(int dictionaryId)
        {
            var dictionary = await userActionsFacade.GetUserDictionaryById(dictionaryId, UserId);
            return StatusCode(dictionary.StatusCode, dictionary.IsSuccess ? dictionary.Value : dictionary.ErrorMessage);
        }
        
        /// <summary>
        /// Updates profile information for the current authenticated user
        /// </summary>
        /// <param name="updateProfileRequestDto">Updated profile data</param>
        /// <returns>Updated user profile</returns>
        /// <response code="200">Profile successfully updated</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="401">Unauthorized access attempt</response>
        [HttpPut]
        public async Task<IActionResult> UpdateProfileData([FromBody] UpdateProfileRequestDto updateProfileRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await userActionsFacade.UpdateUserProfile(UserId, updateProfileRequestDto);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }
        
        /// <summary>
        /// Updates password for the current authenticated user
        /// </summary>
        /// <param name="updatePasswordRequestDto">Password change request</param>
        /// <returns>Success/failure message</returns>
        /// <response code="200">Password successfully updated</response>
        /// <response code="400">Invalid request data or password requirements not met</response>
        /// <response code="401">Unauthorized access attempt</response>
        [HttpPut]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequestDto updatePasswordRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await userActionsFacade.UpdateUserPassword(UserId, updatePasswordRequestDto);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshTokenRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateTokens([FromBody] RefreshTokenRequestDto refreshTokenRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await userActionsFacade.UpdateAllTokens(refreshTokenRequestDto);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }
        
        /// <summary>
        /// Enrolls the current user in a new course
        /// </summary>
        /// <param name="courseId">ID of the course to start</param>
        /// <returns>Course enrollment confirmation</returns>
        /// <response code="200">Successfully enrolled in course</response>
        /// <response code="400">Invalid course ID or already enrolled</response>
        /// <response code="401">Unauthorized access attempt</response>
        /// <response code="404">Course not found</response>
        [HttpPost("{courseId:int}")]
        public async Task<IActionResult> StartCourse(long courseId)
        {
            var response = await userActionsFacade.StartNewCourse(UserId, courseId);
            return StatusCode(response.StatusCode, response.IsSuccess ? response.Value : response.ErrorMessage);
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="userLifeCount"></param>
        /// <returns></returns>
        [HttpPost("{courseId:int}")]
        public async Task<IActionResult> CompleteLesson(long courseId, int userLifeCount)
        {
            var response = await userActionsFacade.CompleteLesson(UserId, courseId, userLifeCount );
            return StatusCode(response.StatusCode, response.IsSuccess ? response.Value : response.ErrorMessage);
        
        }
        
        /// <summary>
        /// Creates a new dictionary for the current authenticated user
        /// </summary>
        /// <param name="addDictionaryRequestDto">Dictionary creation data</param>
        /// <returns>Newly created dictionary</returns>
        /// <response code="201">Dictionary successfully created</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="401">Unauthorized access attempt</response>
        [HttpPost]
        public async Task<IActionResult> AddNewDictionary([FromBody] AddDictionaryRequestDto addDictionaryRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await userActionsFacade.AddNewDictionary(UserId, addDictionaryRequestDto);
            return StatusCode(response.StatusCode, response.IsSuccess ? response.Value : response.ErrorMessage);
        }
        
        /// <summary>
        /// Updates an existing dictionary for the current authenticated user
        /// </summary>
        /// <param name="dictionaryId">ID of the dictionary to update</param>
        /// <param name="updateDictionaryRequestDto">Updated dictionary data</param>
        /// <returns>Updated dictionary</returns>
        /// <response code="200">Dictionary successfully updated</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="401">Unauthorized access attempt</response>
        /// <response code="403">Dictionary doesn't belong to user</response>
        /// <response code="404">Dictionary not found</response>
        [HttpPut("{dictionaryId:int}")]
        public async Task<IActionResult> UpdateDictionary(int dictionaryId, [FromBody] UpdateDictionaryRequestDto updateDictionaryRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await userActionsFacade.UpdateDictionary(UserId, dictionaryId, updateDictionaryRequestDto);
            return StatusCode(response.StatusCode, response.IsSuccess ? response.Value : response.ErrorMessage);
        }
        
        /// <summary>
        /// Deletes a dictionary for the current authenticated user
        /// </summary>
        /// <param name="id">ID of the dictionary to delete</param>
        /// <returns>Success/failure message</returns>
        /// <response code="200">Dictionary successfully deleted</response>
        /// <response code="401">Unauthorized access attempt</response>
        /// <response code="403">Dictionary doesn't belong to user</response>
        /// <response code="404">Dictionary not found</response>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDictionary(int id)
        {
            var result = await userActionsFacade.DeleteDictionary(UserId, id);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }
    }
}
