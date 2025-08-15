using Datass.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datass.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> ValidateCredentialsAsync(string email, string password)
        {
            return await _context.Set<User>()
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
