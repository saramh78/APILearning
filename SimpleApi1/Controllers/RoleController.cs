using Microsoft.AspNetCore.Mvc;
using SimpleApi1.Dtos;
using SimpleApi1.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // Post api/role/Add
        [HttpPost("Add")]
        public async Task<ActionResult<RoleDto>> Add(RoleDto roleDto)
        {
            return await _roleService.addAsync(roleDto);
        }

        //Get  api/role/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoleDto>>> GetAll()
        {
            return await _roleService.GetAllAsync();
        }

        [HttpGet("GetRoleUser")]
        public async Task<ActionResult<List<RoleDto>>> GetRoleUser(int roleId)
        {
            throw new NotImplementedException();
        }

    }
}
