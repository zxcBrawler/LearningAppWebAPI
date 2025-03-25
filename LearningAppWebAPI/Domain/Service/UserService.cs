using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service
{
    public class UserService(UserRepository userRepository, RoleRepository roleRepository)
    {
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();

        public async Task<List<UserSimpleDto>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();
            return users.Select(_mapper.Map<UserSimpleDto>).ToList();
        }

        public async Task<UserSimpleDto?> GetUserById(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserSimpleDto>(user);
        }

        public async Task<UserSimpleDto?> CreateUserAsync(AddUserRequestDTO requestDto)
        {
            var role = await roleRepository.GetByIdAsync(requestDto.Role_Id);

            if (role == null)
            {
                return null;
            }

            User user = new()
            {
                Username = requestDto.Username,
                Email = requestDto.Email,
                Registration_Date = DateTime.UtcNow,
                Profile_Picture = requestDto.Profile_Picture,
                Level = requestDto.Level,
                Current_XP = requestDto.Current_XP,
                Role_Id = role.Id,
                Role = role,
                Password_Hash = requestDto.Password
            };

            await userRepository.CreateAsync(user);
            return _mapper.Map<UserSimpleDto>(user);
        }

        public async Task<bool> UpdateUserAsync(int id, AddUserRequestDTO updateRequest)
        {
            var role = await roleRepository.GetByIdAsync(updateRequest.Role_Id);

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
            currentUser.Current_XP = updateRequest.Current_XP;
            currentUser.Level = updateRequest.Level;
            currentUser.Role = role;
            currentUser.Role_Id = role.Id;

            return await userRepository.UpdateAsync(id, currentUser);
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await userRepository.DeleteAsync(id);
        }
    }
}
