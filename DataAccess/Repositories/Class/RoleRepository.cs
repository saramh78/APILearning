using DataAccess.Model;

using DataAccess.Models;
using DataAccess.Repositories.Interface;

namespace DataAccess.Repositories
{
    public class RoleRepository : BaseRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(LearnApiContext learnApiContext) : base(learnApiContext)
        {
        }

        public void UpdateRule(Role oldrole, Role newrole)
        {

        }

    }

}
