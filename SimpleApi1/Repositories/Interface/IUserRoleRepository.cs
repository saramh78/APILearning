using SimpleApi1.Models;

namespace SimpleApi1.Repositories.Interface
{
    public interface IUserRoleRepository : IBaseRepository<UserRole, int>
    {
        void UpdateUserRole(UserRole oldUserRoleId, UserRole NewUserRoleId);
    }
}
