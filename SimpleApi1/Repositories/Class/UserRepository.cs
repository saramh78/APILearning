using SimpleApi1.Models;
using SimpleApi1.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi1.Repositories.Class
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository()
        {

        }
        public override User Add(User user)
        {
            user.Id = _entities.Count() + 1;
            user.CreateOn = DateTime.Now;
            _entities.Add(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
