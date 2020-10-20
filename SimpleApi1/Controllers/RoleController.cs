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
        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> Get()
        {
            return await _roleService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetAsync(int id)
        {
            var service = await _roleService.GetAsync(id);
            return service;
        }

    }
}
