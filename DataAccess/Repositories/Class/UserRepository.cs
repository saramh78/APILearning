using DataAccess.Model;
using DataAccess.Models;
using DataAccess.Repositories.Interface;
using DataAccess.ViewDataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
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

        public UserViewDataModel GetUserByIdLinqToObject(int userid)
        {
            return (from u in _context.Set<User>()
                    join ur in _context.Set<UserRole>() on u.Id equals ur.UserId
                    join r in _context.Set<Role>() on ur.RoleId equals r.Id
                    where u.Id == userid
                    select new UserViewDataModel { FirstName = u.FirstName, LastName = u.LastName, RoleName = r.Name }
                     ).FirstOrDefault();
        }

        public User GetUserByIdLinqToObject2(int userid)
        {
            var query = "select FirstName,LastName from Users as u" +
                       "join UserRoles as ur on u.Id = ur.UserId " +
                       "join Roles as r on ur.RoleId = r.Id" +
                       $"u.Id =@userId";

            var user = _context.Users.FromSql(query, new SqlParameter("@userId",userid)).FirstOrDefault();
            return user;

        }
    }
}
