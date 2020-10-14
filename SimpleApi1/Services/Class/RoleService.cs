using DataAccess.Repositories.Interface;
using SimpleApi1.Dtos;
using SimpleApi1.Mapper;
using SimpleApi1.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi1.Services.Class
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<RoleDto> addAsync(RoleDto roleDto)
        {
            var role1 = roleDto.RoleDtoToRole();
            var role2 = await _roleRepository.AddAsync(role1);
            return role2.RoleToRoleDto();           
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return roles.RolesToRolesDto();
        }
    }
}
