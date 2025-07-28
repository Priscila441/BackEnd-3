using Models.Entity;

namespace Datass.Repository.Interfaces
{
    public interface ICartDetailRepository : IGenericRepository<CartDetailProduct>
    {
        Task<CartDetailProduct?> GetByCartAndProductIdAsync(int productId, int CartId);
    }
}
