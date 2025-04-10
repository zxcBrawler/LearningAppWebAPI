using System.Diagnostics.CodeAnalysis;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Domain.Service.Impl;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// The UsersController manages user-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "admin")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        /// <response code="200">Returns the list of users.</response>

        [HttpGet]
        [ProducesResponseType(typeof(List<UserSimpleDto>), 200)]
        public async Task<IActionResult> GetUser()
        {
            var result = await userService.GetAllUsersAsync();
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }

        /// <summary>
        /// Gets a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user details.</returns>
        /// <response code="200">Returns the users details.</response>
        /// <response code="404">If the user is not found.</response>

        // GET: api/Users/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserComplexDto), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await userService.GetUserByIdAsync(id);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }
        /// <summary>
        /// Adds new User
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST api/Users
        ///     {
        ///       
        ///        "username": "MyNewUsername",
        ///        "password": "some password",
        ///        "profile_Picture": "https://",
        ///        "email": "email@gmail.com",
        ///        "role_Id": 1,
        ///        "level": 2,
        ///        "current_XP": 2 
        ///     }
        ///
        /// </remarks>
        /// <param name="requestDto">User</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostUser(AddUserRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await userService.CreateUserAsync(requestDto);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="updateRequest">The updated user data.</param>
        /// <returns>No content if successful.</returns>
        /// <response code="204">If the user is updated successfully.</response>
        /// <response code="400">If the ID does not match the user data.</response>
        /// <response code="404">If the user is not found.</response>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] AddUserRequestDto updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await userService.UpdateUserAsync(id, updateRequest);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }

       

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>No content if successful.</returns>
        /// <response code="204">If the user is deleted successfully.</response>
        /// <response code="404">If the user is not found.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await userService.DeleteUserAsync(id);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }
        
    }
}
