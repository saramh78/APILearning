using DataAccess.Model;
using SimpleApi1.Dtos;
using System;
using System.Collections.Generic;

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
                Id =  role.Id                
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
