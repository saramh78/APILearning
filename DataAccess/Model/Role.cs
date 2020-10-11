using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class Role : BaseEntity<long>
    {

        //public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }


    }

}
