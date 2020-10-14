using DataAccess.Model;

using DataAccess.Models;
using DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public override async Task<Role> FindAsync(int id)
        {
            return await _context.Set<Role>()
                 .Include(x => x.UserRoles)
                 .ThenInclude(x => x.User)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

    }

}
