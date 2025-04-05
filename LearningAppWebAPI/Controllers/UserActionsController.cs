using System.Security.Claims;
using LearningAppWebAPI.Domain.Facade;
using LearningAppWebAPI.Models.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// All user-specific actions. Requires authorization
    /// </summary>
    /// <param name="userActionsFacade"></param>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "users")]
    [ApiController]
    public class UserActionsController(IUserActionsFacade userActionsFacade) : BasicController
    {
        /// <summary>
        ///  Get a list of current user's courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserCourses()
        {
            var courses = await userActionsFacade.GetUserCourses(UserId);
            return StatusCode(courses.StatusCode, courses.IsSuccess ? courses.Value : courses.ErrorMessage);
        }
        /// <summary>
        /// Get a list of user dictionaries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserDictionaries()
        {
            var dictionaries = await userActionsFacade.GetUserDictionaries(UserId);
            return StatusCode(dictionaries.StatusCode, dictionaries.IsSuccess ? dictionaries.Value : dictionaries.ErrorMessage);
        }
        /// <summary>
        /// Get single dictionary by dictionary id
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        [HttpGet("{dictionaryId:int}")]
        public async Task<IActionResult> GetUserDictionaryById(int dictionaryId)
        {
            var dictionary = await userActionsFacade.GetUserDictionaryById(dictionaryId, UserId);
            return StatusCode(dictionary.StatusCode, dictionary.IsSuccess ? dictionary.Value : dictionary.ErrorMessage);
        }
        
        /// <summary>
        /// Updates user profile data. All fields are required
        /// </summary>
        /// <param name="updateProfileRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
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
        /// Updates user password. Old password and new password
        /// </summary>
        /// <param name="updatePasswordRequestDto"></param>
        /// <returns></returns>
        [HttpPatch]
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
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpPost("{courseId:int}")]
        public async Task<IActionResult> StartCourse(int courseId)
        {
            var response = await userActionsFacade.StartNewCourse(UserId, courseId);
            return StatusCode(response.StatusCode, response.IsSuccess ? response.Value : response.ErrorMessage);
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> ArchiveCourse(int id)
        {
            return Ok();
        }

        /// <summary>
        /// User action. Adds new dictionary for current authenticated user
        /// </summary>
        ///  <param name="addDictionaryRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewDictionary([FromBody] AddDictionaryRequestDto addDictionaryRequestDto)
        {
            var response = await userActionsFacade.AddNewDictionary(UserId, addDictionaryRequestDto);
            return StatusCode(response.StatusCode, response.IsSuccess ? response.Value : response.ErrorMessage);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddWordToDictionary()
        {
            return Ok();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateDictionary()
        {
            return Ok();
        }
        
        /// <summary>
        /// Deletes dictionary by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDictionary(int id)
        {
            var result = await userActionsFacade.DeleteDictionary(id);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }
    }
}
