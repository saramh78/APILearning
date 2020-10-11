using DataAccess.Model;
using DataAccess.Repositories.Interface;

namespace DataAccess.Repositories
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
