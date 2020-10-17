using DataAccess.Model;
using SimpleApi1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleApi1.Mapper
{
    public static class RoleMapper
    {
        public static Role RoleDtoToRole(this RoleDto roleDto)
        {
            return new Role()
            {
                Name = roleDto.Name,
            };
        }

        public static RoleDto RoleToRoleDto(this Role role)
        {
            return new RoleDto()
            {
                Name = role.Name,
                Id =  role.Id,
                UserDtos = role.UserRoles != null ? role.UserRoles.Select(x => new UserDto2() { UserName = x.User.UserName, FirstName=x.User.FirstName, LastName=x.User.LastName }).ToList() : null
            };
        }


        public static List<RoleDto> RolesToRolesDto(this List<Role> roles)
        {
            if (roles == null)
            {
                throw new ArgumentNullException(nameof(roles));
            }
            var roleDtos = new List<RoleDto>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleDtos.Add(roles[i].RoleToRoleDto());
            }

            return roleDtos;
        }


    }

}
