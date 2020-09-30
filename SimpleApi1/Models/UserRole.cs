using SimpleApi1.Repositories.Interface;

namespace SimpleApi1.Models
{
    public class UserRole : BaseEntity<int>
    {
        //public int Id { get; set; }

        public int Roleid { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
