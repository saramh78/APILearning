using SimpleApi1.Models;
using System.Collections.Generic;

namespace SimpleApi1.Repositories.Interface
{
    public interface IRoleRepository : IBaseRepository<Role, long>
    {
        void UpdateRule(Role oldRole, Role newRole);
    }
}
