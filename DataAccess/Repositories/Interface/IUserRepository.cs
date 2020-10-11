using DataAccess.Model;

namespace DataAccess.Repositories.Interface
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        User UpdateUser(User user);
    }
}
