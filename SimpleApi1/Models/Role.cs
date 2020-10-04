using SimpleApi1.Repositories.Interface;
using System.Collections.Generic;

namespace SimpleApi1.Models
{
    public class Role : BaseEntity<long>
    {
        public int ss;
        //public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        
    }
}
