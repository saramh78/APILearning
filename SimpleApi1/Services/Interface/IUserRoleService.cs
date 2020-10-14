using SimpleApi1.Dtos;
using System.Threading.Tasks;

namespace SimpleApi1.Services.Interface
{
    public interface IUserRoleService
    {
        Task<UserRoleDto> AddAsync(UserRoleDto userRoleDto);
    }
}
