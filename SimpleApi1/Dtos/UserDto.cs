using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi1.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NationalCode { get; set; }
        public string UserName { get; set; }
        public DateTime CreateOn { get; set; }
        public List<RoleDto> RoleDtos { get; set; }
    }
}
