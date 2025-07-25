﻿using Models.Entity;
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
        IGenericRepository<CartDetailProduct> CartDetails { get; }
        ICartRepository Carts { get; }

        Task<int> SaveAsync();
    }
}
