using Datass.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entity;

namespace Datass.Repository
{
    public class CartDetailRepository : GenericRepository<CartDetailProduct> , ICartDetailRepository
    {
        public CartDetailRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<CartDetailProduct?> GetByCartAndProductIdAsync(int productId, int cartId)
        {
            return await _context.CartDetailProducts
                .FirstOrDefaultAsync(cd => cd.ProductId == productId && cd.CartId == cartId);
        }

    }
}
