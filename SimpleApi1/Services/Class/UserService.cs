using DataAccess.Model;
using DataAccess.Repositories.Interface;
using SimpleApi1.Dtos;
using SimpleApi1.Mapper;
using SimpleApi1.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            foreach(var ur in userDto.RoleId)
            {
                UserRole userRole = new UserRole() { RoleId = ur, UserId = user2.Id };
                var userRole2 = _userRoleRepository.Add(userRole);
         //       user2.UserRoles.Add(userRole);
            }
            return user2.UserToUserDtoForAdd();
        }


        public UserDto AddEager(UserDto userDto)
        {
            var user1 = userDto.UserDtoToUserEager2();
            var user2 = _userRepository.Add(user1);
            return user2.UserToUserDtoForAdd();
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
            return user.UserToUserDtoForGet();
        }

        public List<UserDto> GetAll()
        {
            return _userRepository.GetAll().UsersToUserDtos();
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.UsersToUserDtos();
        }

        public async Task<UserDto> GetAsync(int userId)
        {
            var user = await _userRepository.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            return user.UserToUserDtoForGet();
        }
    }
}
