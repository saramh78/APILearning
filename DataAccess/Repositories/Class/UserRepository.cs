using DataAccess.Model;
using DataAccess.Models;
using DataAccess.Repositories.Interface;
using System;
using System.Linq;

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

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
