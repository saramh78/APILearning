using System.Collections.Generic;

namespace DataAccess.Model
{
    public class Role : BaseEntity<int>
    {

        //public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }


    }

}
