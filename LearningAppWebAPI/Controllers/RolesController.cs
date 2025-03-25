using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Models.DTO.Simple;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "users")]
    public class RolesController(RoleService roleService) : ControllerBase
    {
        private readonly RoleService _roleService = roleService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleSimpleDto>>> GetRole()
        {
            return Ok(await _roleService.GetAllRolesAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RoleSimpleDto>> GetRole(int id)
        {
            var role = await _roleService.GetRoleById(id);

            if (role == null)
            {
                return NotFound($"Role with id {id} not found");
            }

            return Ok(role);
        }


        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
        }


        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
        }*/


    }
}
