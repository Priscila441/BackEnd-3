using Datass.Repository.Interfaces;
using Models.Entity;

namespace Datass.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<CartDetailProduct> CartDetails { get; }
        public ICartRepository Carts { get; }
        public UnitOfWork(AppDbContext context, IGenericRepository<Product> productRepo, IGenericRepository<Category> categoryRepo, IGenericRepository<CartDetailProduct> cartDetailRepo, ICartRepository cartRepo) {
            _context = context;
            Products = productRepo;
            Categories = categoryRepo;
            CartDetails = cartDetailRepo;
            Carts = cartRepo;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
