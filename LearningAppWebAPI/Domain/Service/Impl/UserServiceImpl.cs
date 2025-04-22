using AutoMapper;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service.Impl
{
    /// <summary>
    /// The user service class
    /// </summary>
    [ScopedService]
    public class UserServiceImpl(UserRepository userRepository, RoleRepository roleRepository, IMapper mapper) : IUserService
    {

        /// <summary>
        /// Gets the all users
        /// </summary>
        /// <returns>A task containing a list of user simple dto</returns>
        public async Task<DataState<List<UserSimpleDto>>> GetAllUsersAsync()
        {
            try
            {
                var users = await userRepository.GetAllAsync();
                var userDtoList = users.Select(mapper.Map<UserSimpleDto>).ToList();
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
        public async Task<DataState<UserSimpleDto>> GetUserByIdAsync(long id)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(id);
                return user == null ? DataState<UserSimpleDto>.Failure("User not found.", StatusCodes.Status404NotFound) : DataState<UserSimpleDto>.Success(mapper.Map<UserSimpleDto>(user), StatusCodes.Status200OK);
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

                var user = new User
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
                return DataState<UserSimpleDto>.Success(mapper.Map<UserSimpleDto>(user), StatusCodes.Status201Created);
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
                currentUser.ProfilePicture = updateRequest.ProfilePicture;
                

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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="updateProfileRequestDto"></param>
        /// <returns></returns>
        public async Task<DataState<bool>> UpdateUserProfile(long userId,
            UpdateProfileRequestDto updateProfileRequestDto)
        {
            try
            {
                var currentUser = await userRepository.GetByIdAsync(userId);
                if (currentUser == null)
                {
                    return DataState<bool>.Failure("User not found.", StatusCodes.Status404NotFound);
                }

                currentUser.Username = updateProfileRequestDto.Username;
                currentUser.Email = updateProfileRequestDto.Email;
                currentUser.ProfilePicture = updateProfileRequestDto.ProfilePicture;
                var result = await userRepository.UpdateAsync(userId, currentUser);
                return result
                    ? DataState<bool>.Success(true, StatusCodes.Status200OK)
                    : DataState<bool>.Failure("User update failed.", StatusCodes.Status400BadRequest);


            }
            catch (Exception e)
            {
                return DataState<bool>.Failure($"Error updating user profile with ID {userId} : {e.Message}",
                    StatusCodes.Status500InternalServerError);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="updatePasswordRequestDto"></param>
        /// <returns></returns>
        public async Task<DataState<bool>> UpdateUserPassword(long userId,
            UpdatePasswordRequestDto updatePasswordRequestDto)
        {
            try
            {
                var currentUser = await userRepository.GetByIdAsync(userId);
                if (currentUser == null)
                {
                    return DataState<bool>.Failure("User not found.", StatusCodes.Status404NotFound);
                }

                if (!PasswordHasher.VerifyPassword(updatePasswordRequestDto.OldPassword, currentUser.PasswordHash))
                {
                    return DataState<bool>.Failure("Old password is invalid", StatusCodes.Status400BadRequest);
                }

                currentUser.PasswordHash = PasswordHasher.HashPassword(updatePasswordRequestDto.NewPassword);
                var result = await userRepository.UpdateAsync(userId, currentUser);
                return result
                    ? DataState<bool>.Success(true, StatusCodes.Status200OK)
                    : DataState<bool>.Failure("User password update failed.", StatusCodes.Status400BadRequest);
            }
            catch (Exception e)
            {
                return DataState<bool>.Failure($"Error updating user password with ID {userId} : {e.Message}",
                    StatusCodes.Status500InternalServerError);
            }
            
        }
    }
}
