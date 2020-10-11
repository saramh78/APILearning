using DataAccess.Model;
using SimpleApi1.Dtos;
using System;
using System.Collections.Generic;

namespace SimpleApi1.Mapper
{
    public static class UserMapper
    {
        public static User UserDtoToUser(this UserDto userDto)
        {
            return new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                NationalCode = userDto.NationalCode,
                Id = userDto.Id,
                UserName = userDto.UserName,
                CreateOn = userDto.CreateOn
                // UserRoles = userDto.RoleDtos.Select(x => new UserRole { Roleid = x.Id, UserId = userDto.Id }).ToList()
            };
        }

        public static UserDto UserToUserDto(this User user)
        {
            return new UserDto()
            {
                FirstName = user.FirstName,
                UserName = user.UserName,
                Id = user.Id,
                LastName = user.LastName,
                NationalCode = user.NationalCode,
                CreateOn=user.CreateOn,
                // RoleDtos = user.UserRoles.Select(x => new RoleDto() { Id = x.Roleid, Name = x.Role.Name }).ToList()
            };
        }

        public static List<UserDto> UsersToUserDtos(this List<User> users)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            var userDtos = new List<UserDto>();
            for (int i = 0; i < users.Count; i++)
            {
                userDtos.Add(users[i].UserToUserDto());
            }

            return userDtos;
        }

        //public static string ToPersianYeKe(this string arabi)
        //{
        //    arabi = arabi.Replace("ك", "ک");
        //    arabi = arabi.Replace("ي", "ی");
        //    return arabi;
        //}

        //public static string ToPersianYeKe2(this string arabi)
        //{
        //    arabi.Replace("ك", "ک");
        //    arabi.Replace("ي", "ی");
        //    return arabi;
        //}




    }


}
