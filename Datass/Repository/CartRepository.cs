using Datass.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entity;


namespace Datass.Repository
{
    public class CartRepository :GenericRepository<Cart> , ICartRepository
    {
        public CartRepository(AppDbContext context) : base (context) {
        }
        public async Task<Cart?> GetActiveCartAsync()
        {
            return await _context.Carts
                .Include(c => c.CartDetail)
                .FirstOrDefaultAsync(static c => c.IsActive);
        }
    }
}
