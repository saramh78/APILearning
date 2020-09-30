using SimpleApi1.Models;
using System.Collections.Generic;

namespace SimpleApi1.Repositories.Interface
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        User UpdateUser(User user);
    }
}
