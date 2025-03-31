using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Utils;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The role service class
    /// </summary>
    [ScopedService]
    public class RoleService(RoleRepository roleRepository)
    {
        /// <summary>
        /// The configure mapper
        /// </summary>
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();

        /// <summary>
        /// Gets the all roles
        /// </summary>
        /// <returns>A task containing a list of role simple dto</returns>
        public async Task<List<RoleSimpleDto>> GetAllRolesAsync()
        {
            var roles = await roleRepository.GetAllAsync();
            return roles.Select(_mapper.Map<RoleSimpleDto>).ToList();
        }

        /// <summary>
        /// Gets the role by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the role simple dto</returns>
        public async Task<RoleSimpleDto?> GetRoleById(int id)
        {
            var role = await roleRepository.GetByIdAsync(id);
            return role == null ? null : _mapper.Map<RoleSimpleDto>(role);
        }

    }
}
