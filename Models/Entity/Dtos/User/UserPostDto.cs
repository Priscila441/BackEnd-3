using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity.Dtos.User
{
    public class UserPostDto
    {
        public required string NameUser { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
