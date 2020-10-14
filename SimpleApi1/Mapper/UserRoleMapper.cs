using DataAccess.Model;
using SimpleApi1.Dtos;

namespace SimpleApi1.Mapper
{
    public static class UserRoleMapper
    {
        public static UserRole UserRoleDtoToUserRole(this UserRoleDto userRoleDto)
        {
            return new UserRole()
            {
                RoleId = userRoleDto.RoleId,
                UserId = userRoleDto.UserId
            };
        }

        public static UserRoleDto UserRoleToUserRoleDto(this UserRole userRole)
        {
            return new UserRoleDto()
            {
                RoleId = userRole.RoleId,
                UserId = userRole.UserId
            };
        }

    }

}
