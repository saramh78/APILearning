using SimpleApi1.Dtos;
using SimpleApi1.Mapper;
using SimpleApi1.Models;
using SimpleApi1.Repositories.Class;
using SimpleApi1.Repositories.Interface;
using SimpleApi1.Services.Interface;
using System;
using System.Collections.Generic;

namespace SimpleApi1.Services.Class
{
    public class UserService : IUserService
    {
        private const int _SYSTEMUSERID = 1;

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository
        )
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._userRoleRepository = userRoleRepository;
        }

        public UserDto Add(UserDto userDto)
        {
            
            var user1 = userDto.UserDtoToUser();
            var user2 = _userRepository.Add(user1);

            return user2.UserToUserDto();
        }
        public bool Delete(int userId)
        {
            //ravesh 1
            //_userRepository.Delete(userId);
            //return true;

            //ravesh2
            var user3 = _userRepository.Find(userId);
            if (user3 == null)
            {
                throw new KeyNotFoundException();
            }
            _userRepository.Delete(user3);
            return true;
        }

        public UserDto Get(int userId)
        {
            var user = _userRepository.Find(userId);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            return user.UserToUserDto();
        }

        public List<UserDto> GetAll()
        {
            return _userRepository.GetAll().UsersToUserDtos();
        }
    }
}
