using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datass.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Category> Categories { get; }
        ICartDetailRepository CartDetails { get; }
        ICartRepository Carts { get; }
        IUserRepository Users { get; }
        IGenericRepository<Order> Orders { get; }
        Task<int> SaveAsync();
    }
}
