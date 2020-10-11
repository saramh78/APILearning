using DataAccess.Model;
using DataAccess.Repositories.Interface;
using System;
using System.Linq;

namespace DataAccess.Repositories
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
