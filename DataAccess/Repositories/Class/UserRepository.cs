using DataAccess.Model;
using DataAccess.Models;
using DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(LearnApiContext learnApiContext) : base(learnApiContext)
        {
        }

        public override User Add(User user)
        {
            user.CreateOn = DateTime.Now;
           return base.Add(user);
        }

        public override async Task<User> FindAsync(int id)
        {
            return await _context.Set<User>()
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override  User Find(int id)
        {
            return _context.Set<User>()
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault(x => x.Id == id);
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
