using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Domain.Service.Impl;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models.DTO.Simple;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// The roles controller class
    /// </summary>
    /// <seealso cref="ControllerBase"/>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "admin")]
    public class RolesController(IRoleService roleService) : ControllerBase
    {
        /// <summary>
        /// Gets the role
        /// </summary>
        /// <returns>A task containing an action result of i enumerable role simple dto</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleSimpleDto>>> GetRole()
        {
            return Ok(await roleService.GetAllRolesAsync());
        }


        /// <summary>
        /// Gets the role using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing an action result of role simple dto</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleSimpleDto>> GetRole(int id)
        {
            var role = await roleService.GetRoleById(id);

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
