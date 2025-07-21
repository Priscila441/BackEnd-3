using Models.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class User
    {
        public int IdUser { get; set; }
        public required string NameUser { get; set; }
        public int Age { get; set; }
        public required string Email { get; set; }
        public RoleUser Role { get; set; } = RoleUser.Invite;

    }
}
