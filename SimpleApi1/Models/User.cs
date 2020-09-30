using SimpleApi1.Repositories.Interface;
using System;
using System.Collections.Generic;

namespace SimpleApi1.Models
{
    public class User : BaseEntity<int>
    {
        //public int Id { get; set; }

        public int NationalCode { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreateOn { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
