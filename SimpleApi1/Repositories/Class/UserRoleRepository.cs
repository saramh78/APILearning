using SimpleApi1.Models;
using SimpleApi1.Repositories.Interface;
using System;

namespace SimpleApi1.Repositories.Class
{
    public class UserRoleRepository : BaseRepository<UserRole, int>, IUserRoleRepository
    {   
        public void UpdateUserRole(UserRole oldur, UserRole newur)
        {
            throw new NotImplementedException();
        }
    }
}
