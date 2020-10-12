using DataAccess.Model;
using DataAccess.Models;
using DataAccess.Repositories.Interface;
using System;

namespace DataAccess.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole, int>, IUserRoleRepository
    {
        public UserRoleRepository(LearnApiContext learnApiContext) : base(learnApiContext)
        {
        }

        public void UpdateUserRole(UserRole oldur, UserRole newur)
        {
            throw new NotImplementedException();
        }
    }
}
