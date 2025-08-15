using Datass.Repository.Interfaces;
using Models.Entity;

namespace Datass.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Category> Categories { get; }
        public ICartDetailRepository CartDetails { get; }
        public ICartRepository Carts { get; }
        public IUserRepository Users { get; }
        public IGenericRepository<Order> Orders { get; }
        public UnitOfWork(AppDbContext context, IGenericRepository<Product> productRepo, IGenericRepository<Category> categoryRepo, ICartDetailRepository cartDetailRepo, ICartRepository cartRepo , IUserRepository  userRepo, IGenericRepository<Order> orderRepo) {
            _context = context;
            Products = productRepo;
            Categories = categoryRepo;
            CartDetails = cartDetailRepo;
            Carts = cartRepo;
            Users = userRepo;
            Orders = orderRepo;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
