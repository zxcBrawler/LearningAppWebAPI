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
        public async Task<List<UserSimpleDto>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();
            return users.Select(_mapper.Map<UserSimpleDto>).ToList();
        }

        /// <summary>
        /// Gets the user by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the user simple dto</returns>
        public async Task<UserSimpleDto?> GetUserById(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserSimpleDto>(user);
        }

        /// <summary>
        /// Creates the user using the specified request dto
        /// </summary>
        /// <param name="requestDto">The request dto</param>
        /// <returns>A task containing the user simple dto</returns>
        public async Task<UserSimpleDto?> CreateUserAsync(AddUserRequestDto requestDto)
        {
            var role = await roleRepository.GetByIdAsync(requestDto.RoleId);

            if (role == null)
            {
                return null;
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
            return _mapper.Map<UserSimpleDto>(user);
        }

        /// <summary>
        /// Updates the user using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="updateRequest">The update request</param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> UpdateUserAsync(int id, AddUserRequestDto updateRequest)
        {
            var role = await roleRepository.GetByIdAsync(updateRequest.RoleId);

            if (role == null)
            {
                return false;
            }

            var currentUser = await userRepository.GetByIdAsync(id);
            if (currentUser == null)
            {
                return false;
            }
            currentUser.Username = updateRequest.Username;
            currentUser.Email = updateRequest.Email;
            currentUser.CurrentXp = updateRequest.CurrentXp;
            currentUser.Level = updateRequest.Level;
            currentUser.Role = role;
            currentUser.RoleId = role.Id;

            return await userRepository.UpdateAsync(id, currentUser);
        }
        /// <summary>
        /// Deletes the user using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await userRepository.DeleteAsync(id);
        }
    }
}
