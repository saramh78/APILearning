using SimpleApi1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi1.Services.Interface
{
    public interface IRoleService
    {
        Task<RoleDto> addAsync(RoleDto roleDto);
        Task<List<RoleDto>> GetAllAsync();
        Task<RoleDto> GetAsync(int roleId);
    }
}
