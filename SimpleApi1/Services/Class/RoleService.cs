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
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public RoleService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository
        )
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._userRoleRepository = userRoleRepository;
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

        public async Task<RoleDto> GetAsync(int roleId)
        {
            var role = await _roleRepository.FindAsync(roleId);
            if (role == null)
            {
                throw new Exception("User Not Found");
            }
            return role.RoleToRoleDto();
        }
    }
}
