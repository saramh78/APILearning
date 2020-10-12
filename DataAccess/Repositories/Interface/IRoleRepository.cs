using DataAccess.Model;

namespace DataAccess.Repositories.Interface
{
    public interface IRoleRepository : IBaseRepository<Role, int>
    {
        void UpdateRule(Role oldRole, Role newRole);
    }
}
