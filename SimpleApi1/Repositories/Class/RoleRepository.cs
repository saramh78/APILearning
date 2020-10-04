using SimpleApi1.Models;
using SimpleApi1.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi1.Repositories.Class
{
    public class RoleRepository : BaseRepository<Role, long>, IRoleRepository
    {
        public RoleRepository()
        {

        }
        //public override Role Find(long id)
        //{
        //    return _entities.FirstOrDefault(x => x.Id == id);
        //}


        public void UpdateRule(Role oldrole, Role newrole)
        {

        }

    }
}
