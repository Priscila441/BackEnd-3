using Datass.Repository.Interfaces;
using Models.Entity;

namespace Datass.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Category> Categories { get; }
        public UnitOfWork(AppDbContext context, IGenericRepository<Product> productRepo, IGenericRepository<Category> categoryRepo) {
            _context = context;
            Products = productRepo;
            Categories = categoryRepo;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
