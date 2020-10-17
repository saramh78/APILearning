using System.Collections.Generic;

namespace SimpleApi1.Dtos
{
    public class RoleDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<UserDto2> UserDtos { get; set; }

    }
}
