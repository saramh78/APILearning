﻿namespace DataAccess.Model
{
    public class UserRole : BaseEntity<int>
    {
        //public int Id { get; set; }

        public int RoleId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
