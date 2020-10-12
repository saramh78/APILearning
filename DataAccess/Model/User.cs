using System;
using System.Collections.Generic;

namespace DataAccess.Model
{

    public class User : BaseEntity<int>
    {
        public int NationalCode { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string Mobile { get; set; }

        public string LastName { get; set; }

        public DateTime CreateOn { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
