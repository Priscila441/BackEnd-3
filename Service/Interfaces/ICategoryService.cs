using Models.Entity.Dtos.Category;
using Models.Entity.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryGetDto>> BringAllAsync();
        Task<CategoryGetDto> BringOneAsync(int id);
        Task<CategoryGetDto> CreateAsync(CategoryPostDto category);
        Task<bool> ChangeAsync(int id, CategoryPutDto category);
        Task<bool> DeleteAsync(int id);

    }
}
