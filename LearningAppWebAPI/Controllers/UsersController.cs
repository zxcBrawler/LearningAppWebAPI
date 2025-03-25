using LearningAppWebAPI.Domain.Service;
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

    [ApiController]
    public class UsersController(UserService userService) : ControllerBase
    {

        private readonly UserService _userService = userService;

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        /// <response code="200">Returns the list of users.</response>

        [HttpGet]
        [ApiExplorerSettings(GroupName = "users")]
        [ProducesResponseType(typeof(List<UserSimpleDto>), 200)]
        public async Task<ActionResult<IEnumerable<UserSimpleDto>>> GetUser()
        {
            return Ok(await _userService.GetAllUsersAsync());
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
        [ApiExplorerSettings(GroupName = "users")]
        [ProducesResponseType(typeof(UserComplexDTO), 200)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<ActionResult<UserSimpleDto>> GetUserById(int id)
        {
            var userSimpleDto = await _userService.GetUserById(id);

            if (userSimpleDto == null)
            {
                return NotFound($"User with id {id} not found");
            }

            return Ok(userSimpleDto);
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
        [ApiExplorerSettings(GroupName = "admin")]
        public async Task<IActionResult> PutUser(int id, [FromBody] AddUserRequestDTO updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isUpdated = await _userService.UpdateUserAsync(id, updateRequest);

            if (!isUpdated)
            {
                return NotFound($"User with id {id} not found");
            }

            return NoContent();
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
        [ApiExplorerSettings(GroupName = "admin")]
        public async Task<ActionResult<UserSimpleDto?>> PostUser(AddUserRequestDTO requestDto)
        {
            var result = await _userService.CreateUserAsync(requestDto);
            if (result == null)
            {
                return NotFound($"Role with id {requestDto.Role_Id} not found");
            }

            return CreatedAtAction("GetUser", new { id = result.Id }, result);

        }

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>No content if successful.</returns>
        /// <response code="204">If the user is deleted successfully.</response>
        /// <response code="404">If the user is not found.</response>
        [HttpDelete("{id}")]
        [ApiExplorerSettings(GroupName = "admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            bool isDeleted = await _userService.DeleteUserAsync(id);

            if (!isDeleted)
            {
                return NotFound($"User with id {id} not found.");
            }

            return NoContent();
        }

        /*
         - [] Enroll to course (int course_Id) -> adds new UserCourse entity
         - [] Archive course (int course_Id) -> Updates Course sets IsArchived param in UserCourse to true 
         - [] Login (LoginRequest loginRequest) -> Logs in with provided credentials, adds credentials to Windows Registry
         - [] Sign up (SignUpRequest signUpRequest) -> Sign up new user, adds new User Entity, hashes password with salt creates access token
         - [] Log out () -> Loggs out of current account, clears access token and Windows Registry
         - [] Update profile data (AddUserRequestDTO addUSerRequestDTO) -> changes all user params except password
         - [] Update password(UpdatePasswordRequestDTO updatePasswordRequstDTO) -> changes user's password, old and new password are required, hashes old password compares it to the one in database
                if matched => proceed to update password
         
         */
    }
}
