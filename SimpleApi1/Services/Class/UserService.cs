using DataAccess.Model;
using DataAccess.Models;
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

        //lazy
        public UserDto Add(UserDto userDto)
        {

            var user1 = userDto.UserDtoToUser();
            var user2 = _userRepository.Add(user1);

            foreach (var ur in userDto.RoleId)
            {
                UserRole userRole = new UserRole() { RoleId = ur, UserId = user2.Id };
                var userRole2 = _userRoleRepository.Add(userRole);
                //       user2.UserRoles.Add(userRole);
            }
            return user2.UserToUserDtoForAdd();
        }

        //eager
        public UserDto AddEager(UserDto userDto)
        {
            var user1 = userDto.UserDtoToUserEager2();
            var user2 = _userRepository.Add(user1);
            return user2.UserToUserDtoForAdd();
        }

        public async Task<UserDto> UpdateUserAsync(int userId, UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await _userRepository.FindAsync(userId);
                if (user == null)
                {
                    throw new Exception($"user not found for userId = {userId}");
                }

                user = userUpdateDto.UserUpdateDtoToUser(user, userId);

                var user2 = await _userRepository.UpdateAsync(user);

                throw new Exception("sddddf");

                return user2.UserToUserDtoForResultUpdate();

            }
            catch (Exception ex)
            {
                //Log Error ex.message;
                throw ex; ;
            }

        }

        public async Task<UserDto> UpdateUserAsync2(int userId, UserUpdateDto userUpdateDto)
        {

            using (var transaction = await _userRoleRepository.Context.Database.BeginTransactionAsync())
            {
                try
                {
                   
                    var user = await _userRepository.FindAsync(userId);
                    if (user == null)
                    {
                        throw new Exception($"user not found for userId = {userId}");
                    }

                    user.LastName = userUpdateDto.LastName;

                    var user2 = await _userRepository.UpdateAsync(user);

                    var userRole = _userRoleRepository.GetAll(x => x.UserId == userId);

                    _userRoleRepository.Delete(userRole);


                    foreach (var item in userUpdateDto.RoleDtos)
                    {
                        await _userRoleRepository.AddAsync(new UserRole
                        {
                            RoleId = item.Id.Value,
                            UserId = userId
                        });
                    }

                    //transaction.Commit();

                    return user2.UserToUserDtoForResultUpdate();

                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    //Log Error ex.message;
                    throw ex; ;
                }

            }


        }

        public UserDtoLinq GetUserByLinq(int userId)
        {
            var user = _userRepository.GetUserByIdLinqToObject(userId);
            return new UserDtoLinq()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleName = user.RoleName
            };
        }
    }
}
