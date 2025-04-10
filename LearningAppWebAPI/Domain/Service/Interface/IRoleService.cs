using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Interface;

public interface IRoleService
{ 
    Task<DataState<List<RoleSimpleDto>>> GetAllRolesAsync();
    Task<DataState<RoleSimpleDto>> GetRoleById(int id);
}