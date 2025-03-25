using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The user service class
    /// </summary>
    public class UserService(UserRepository userRepository, RoleRepository roleRepository)
    {
        /// <summary>
        /// The configure mapper
        /// </summary>
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();

        /// <summary>
        /// Gets the all users
        /// </summary>
        /// <returns>A task containing a list of user simple dto</returns>
        public async Task<DataState<List<UserSimpleDto>>> GetAllUsersAsync()
        {
            try
            {
                var users = await userRepository.GetAllAsync();
                var userDtoList = users.Select(_mapper.Map<UserSimpleDto>).ToList();
                return DataState<List<UserSimpleDto>>.Success(userDtoList, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return DataState<List<UserSimpleDto>>.Failure($"Error getting all users: {ex.Message}", StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gets the user by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the user simple dto</returns>
        public async Task<DataState<UserSimpleDto>> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(id);
                return user == null ? DataState<UserSimpleDto>.Failure("User not found.", StatusCodes.Status404NotFound) : DataState<UserSimpleDto>.Success(_mapper.Map<UserSimpleDto>(user), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return DataState<UserSimpleDto>.Failure($"Error getting user with ID {id}: {ex.Message}", StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Creates the user using the specified request dto
        /// </summary>
        /// <param name="requestDto">The request dto</param>
        /// <returns>A task containing the user simple dto</returns>
        public async Task<DataState<UserSimpleDto>> CreateUserAsync(AddUserRequestDto requestDto)
        {
            try
            {
                var role = await roleRepository.GetByIdAsync(requestDto.RoleId);
                if (role == null)
                {
                    return DataState<UserSimpleDto>.Failure("Role not found.", StatusCodes.Status404NotFound);
                }

                User user = new()
                {
                    Username = requestDto.Username,
                    Email = requestDto.Email,
                    RegistrationDate = DateTime.UtcNow,
                    ProfilePicture = requestDto.ProfilePicture,
                    Level = requestDto.Level,
                    CurrentXp = requestDto.CurrentXp,
                    RoleId = role.Id,
                    Role = role,
                    PasswordHash = requestDto.Password
                };

                await userRepository.CreateAsync(user);
                return DataState<UserSimpleDto>.Success(_mapper.Map<UserSimpleDto>(user), StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return DataState<UserSimpleDto>.Failure($"Error creating user: {ex.Message}", StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Updates the user using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="updateRequest">The update request</param>
        /// <returns>A task containing the bool</returns>
        public async Task<DataState<bool>> UpdateUserAsync(int id, AddUserRequestDto updateRequest)
        {
            try
            {
                var role = await roleRepository.GetByIdAsync(updateRequest.RoleId);
                if (role == null)
                {
                    return DataState<bool>.Failure("Role not found.", StatusCodes.Status404NotFound);
                }

                var currentUser = await userRepository.GetByIdAsync(id);
                if (currentUser == null)
                {
                    return DataState<bool>.Failure("User not found.", StatusCodes.Status404NotFound);
                }

                currentUser.Username = updateRequest.Username;
                currentUser.Email = updateRequest.Email;
                currentUser.CurrentXp = updateRequest.CurrentXp;
                currentUser.Level = updateRequest.Level;
                currentUser.Role = role;
                currentUser.RoleId = role.Id;

                var updateResult = await userRepository.UpdateAsync(id, currentUser);
                return !updateResult ? DataState<bool>.Failure("User update failed.", StatusCodes.Status400BadRequest) : DataState<bool>.Success(true, StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return DataState<bool>.Failure($"Error updating user with ID {id}: {ex.Message}", StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Deletes the user using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the bool</returns>
        public async Task<DataState<bool>> DeleteUserAsync(int id)
        {
            try
            {
                var deleteResult = await userRepository.DeleteAsync(id);
                return !deleteResult ? DataState<bool>.Failure("User deletion failed.", StatusCodes.Status400BadRequest) : DataState<bool>.Success(true, StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return DataState<bool>.Failure($"Error deleting user with ID {id}: {ex.Message}", StatusCodes.Status500InternalServerError);
            }
        }
    }
}
