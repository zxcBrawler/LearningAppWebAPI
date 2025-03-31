using System.Net;
using LearningAppWebAPI.Domain.Facade;
using LearningAppWebAPI.Models.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userActionsFacade"></param>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "users")]
    [Authorize]
    [ApiController]
    public class UserActionsController(UserActionsFacade userActionsFacade) : ControllerBase
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserCourses()
        {
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserDictionaries()
        {
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserDictionaryById(int id)
        {
            return Ok();
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateProfileData()
        {
            return Ok();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> UpdatePassword()
        {
            return Ok();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id:int}")]
        public async Task<IActionResult> StartCourse(int id)
        {
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> StopCourse(int id)
        {
            return Ok();
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
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewDictionary()
        {
            return Ok();
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDictionary(int id)
        {
            return Ok();
        }
    }
    /*
        - [] Enroll to course (int course_Id) -> adds new UserCourse entity
        - [] Archive course (int course_Id) -> Updates Course sets IsArchived param in UserCourse to true
        - [] Add Dictionary
        - [] Add word to dictionary
        - [] Update dictionary
        - [] Delete dictionary
        
        (separate endpoints)
        - [] Get current user courses
        - [] Get current user dictionaries
        (separate endpoints)
        
        - [] Update profile data (AddUserRequestDTO addUSerRequestDTO) -> changes all user params except password
        - [] Update password(UpdatePasswordRequestDTO updatePasswordRequstDTO) -> changes user's password, old and new password are required, hashes old password compares it to the one in database
               if matched => proceed to update password

        */
}
