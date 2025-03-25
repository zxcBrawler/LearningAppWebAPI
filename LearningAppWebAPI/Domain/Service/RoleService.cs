using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service
{
    public class RoleService(RoleRepository roleRepository)
    {
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();

        public async Task<List<RoleSimpleDto>> GetAllRolesAsync()
        {
            var roles = await roleRepository.GetAllAsync();
            return roles.Select(_mapper.Map<RoleSimpleDto>).ToList();
        }

        public async Task<RoleSimpleDto?> GetRoleById(int id)
        {
            var role = await roleRepository.GetByIdAsync(id);
            return role == null ? null : _mapper.Map<RoleSimpleDto>(role);
        }

    }
}
