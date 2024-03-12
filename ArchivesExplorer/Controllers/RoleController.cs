using ArchivesExplorer.Requests;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Constants;
using ArchivexExplorer.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchivesExplorer.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserConstants.SuperUserRole)]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleModel>>> GetAllRoles()
        {
            var result = await _roleService.GetAllRoles();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            await _roleService.CreateRole(_mapper.Map<RoleModel>(request));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole([FromRoute] string id)
        {
            await _roleService.DeleteRole(Guid.Parse(id));

            return Ok();
        }
    }
}
