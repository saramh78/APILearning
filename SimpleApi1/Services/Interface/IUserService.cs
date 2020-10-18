using SimpleApi1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi1.Services.Interface
{
    public interface IUserService
    {
        UserDto Add(UserDto userDto);
        UserDto Get(int userId);
        Task<UserDto> GetAsync(int userId);
        bool Delete(int userId);
        List<UserDto> GetAll();
        Task<List<UserDto>> GetAllAsync();
        UserDto AddEager(UserDto userDto);
    }
}
