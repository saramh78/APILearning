using DataAccess.Model;
using DataAccess.ViewDataModel;

namespace DataAccess.Repositories.Interface
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        UserViewDataModel GetUserByIdLinqToObject(int userid);
        User UpdateUser(User user);
    }
}
