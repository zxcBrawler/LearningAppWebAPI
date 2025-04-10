using AutoMapper;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service.Impl
{
    /// <summary>
    /// The role service class
    /// </summary>
    [ScopedService]
    public class RoleServiceImpl(RoleRepository roleRepository, IMapper mapper) : IRoleService
    {

        /// <summary>
        /// Gets the all roles
        /// </summary>
        /// <returns>A task containing a list of role simple dto</returns>
        public async Task<DataState<List<RoleSimpleDto>>> GetAllRolesAsync()
        {
            try
            {
                var roles = await roleRepository.GetAllAsync();
                return DataState<List<RoleSimpleDto>>.Success(roles.Select(mapper.Map<RoleSimpleDto>).ToList(), StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
               return DataState<List<RoleSimpleDto>>.Failure("Error getting list of roles", StatusCodes.Status500InternalServerError);
            }
           
        }

        /// <summary>
        /// Gets the role by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the role simple dto</returns>
        public async Task<DataState<RoleSimpleDto>> GetRoleById(int id)
        {
            try
            {
                var role = await roleRepository.GetByIdAsync(id);
                return DataState<RoleSimpleDto>.Success(mapper.Map<RoleSimpleDto>(role), StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return DataState<RoleSimpleDto>.Failure($"Error getting role with id {id}", StatusCodes.Status500InternalServerError);
            }
          
        }

    }
}
