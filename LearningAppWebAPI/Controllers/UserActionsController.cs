using System.Security.Claims;
using LearningAppWebAPI.Domain.Facade;
using LearningAppWebAPI.Models.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userActionsFacade"></param>
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
        public async Task<IActionResult> GetUserCourses()
        {
            var courses = await userActionsFacade.GetUserCourses(UserId);
            return Ok(courses);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserDictionaries()
        {
            var dictionaries = await userActionsFacade.GetUserDictionaries(UserId);
            return Ok(dictionaries);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        [HttpGet("{dictionaryId:int}")]
        public async Task<IActionResult> GetUserDictionaryById(int dictionaryId)
        {
            var dictionary = await userActionsFacade.GetUserDictionaryById(dictionaryId, UserId);
            return Ok(dictionary);
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateProfileData([FromBody] UpdateProfileRequestDto updateProfileRequestDto)
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
        public async Task<IActionResult> AddNewDictionary([FromBody] AddDictionaryRequestDto addDictionaryRequestDto)
        {
            var response = await userActionsFacade.AddNewDictionary(UserId, addDictionaryRequestDto);
            return StatusCode(response.StatusCode, response.Value);
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
            var result = await userActionsFacade.DeleteDictionary(id);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }
    }
}
