using DataAccess.Model;
using SimpleApi1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

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
                UserName = userDto.UserName,
                CreateOn = userDto.CreateOn,
              //  UserRoles = userDto.RoleDtos.Select(x => new UserRole { RoleId = x.Id.Value, UserId = userDto.Id }).ToList()
            };


        }



        public static User UserDtoToUserEager(this UserDto userDto)
        {
            return new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                NationalCode = userDto.NationalCode,
                UserName = userDto.UserName,
                CreateOn = userDto.CreateOn,
                UserRoles = userDto.RoleDtos.Select(x => new UserRole { RoleId = x.Id.Value, UserId = userDto.Id }).ToList()
            };
        }

        public static User UserDtoToUserUpdate(this UserDto userDto,User user)
        {
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.NationalCode = userDto.NationalCode;
            user.UserName = userDto.UserName;
            user.UserRoles = userDto.RoleDtos.Select(x => new UserRole { RoleId = x.Id.Value, UserId = userDto.Id }).ToList();
            return user; 

        }

        public static User UserDtoToUserEager2(this UserDto userDto)
        {
            return new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                NationalCode = userDto.NationalCode,
                UserName = userDto.UserName,
                CreateOn = userDto.CreateOn,
                UserRoles = userDto.RoleId != null  && userDto.RoleId?.Count > 0 ?  userDto.RoleId.Select(x => new UserRole { RoleId = x, UserId = userDto.Id }).ToList() : null
            };
        }


        public static UserDto UserToUserDtoForAdd(this User user)
        {
            return new UserDto()
            {
                FirstName = user.FirstName,
                UserName = user.UserName,
                Id = user.Id,
                LastName = user.LastName,
                NationalCode = user.NationalCode,
                CreateOn = user.CreateOn,
            };
        }


        public static UserDto UserToUserDtoForGet(this User user)
        {
            return new UserDto()
            {
                FirstName = user.FirstName,
                UserName = user.UserName,
                Id = user.Id,
                LastName = user.LastName,
                NationalCode = user.NationalCode,
                CreateOn=user.CreateOn,
                RoleDtos = user.UserRoles != null ?  user.UserRoles.Select(x => new RoleDto() { Name = x.Role.Name }).ToList() : null
            };
        }

        public static UserDto UserToUserDtoForResultUpdate(this User user)
        {
            return new UserDto()
            {
                FirstName = user.FirstName,
                UserName = user.UserName,
                Id = user.Id,
                LastName = user.LastName,
                NationalCode = user.NationalCode,
                CreateOn = user.CreateOn,
              //  RoleDtos = user.UserRoles != null ? user.UserRoles.Select(x => new RoleDto() { Name = x.Role.Name }).ToList() : null
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
                userDtos.Add(users[i].UserToUserDtoForGet());
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


        public static User UserUpdateDtoToUser(this UserUpdateDto userUpdateDto,User user,int userId)
        {
            user.LastName = userUpdateDto.LastName;
            user.UserRoles = userUpdateDto.RoleDtos.Select(x => new UserRole { RoleId = x.Id.Value, UserId = userId }).ToList();
            return user;

        }
    }


}
