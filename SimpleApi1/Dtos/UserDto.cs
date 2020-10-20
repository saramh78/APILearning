using System;
using System.Collections.Generic;

namespace SimpleApi1.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public DateTime CreateOn { get; set; }
        public List<int> RoleId { get; set; }
        public List<RoleDto> RoleDtos { get; set; }
    }

    public class UserUpdateDto
    {
        public string LastName { get; set; }
        public List<RoleDto> RoleDtos { get; set; }
    }

    public class UserDtoLinq
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
    }
}
