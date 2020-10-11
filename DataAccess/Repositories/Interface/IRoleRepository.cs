using DataAccess.Model;

namespace DataAccess.Repositories.Interface
{
    public interface IRoleRepository : IBaseRepository<Role, long>
    {
        void UpdateRule(Role oldRole, Role newRole);
    }
}
