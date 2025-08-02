using Models.Entity.Enums;
using System.ComponentModel.DataAnnotations;

namespace Models.Entity
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public required string NameUser { get; set; }
        public int Age { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public RoleUser Role { get; set; } = RoleUser.Invite;
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
