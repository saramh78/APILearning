using DataAccess.Repositories.Interface;
using SimpleApi1.Dtos;
using SimpleApi1.Mapper;
using SimpleApi1.Services.Interface;
using System;
using System.Threading.Tasks;

namespace SimpleApi1.Services.Class
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        public async Task<UserRoleDto> AddAsync(UserRoleDto userRoleDto)
        {
            var userRole1 = userRoleDto.UserRoleDtoToUserRole();
            var userRole2 = await _userRoleRepository.AddAsync(userRole1);
            return userRole2.UserRoleToUserRoleDto();
        }
    }
}
