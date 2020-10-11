using DataAccess.Model;

namespace DataAccess.Repositories.Interface
{
    public interface IUserRoleRepository : IBaseRepository<UserRole, int>
    {
        void UpdateUserRole(UserRole oldUserRoleId, UserRole NewUserRoleId);
    }
}
