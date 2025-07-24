
using Models.Entity.Dtos.Product;

namespace Service.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductGetDto>> BringAllAsync();
        Task<ProductGetDto> BringOneAsync(int id);
        Task<ProductGetDto> CreateAsync(ProductPostDto product);
        Task<bool> ChangeAsync(int id, ProductPutDto product);
        Task<bool> DeleteAsync(int id);
        //cambiar el estado del producto cuando el valor del stock sea 0
    }
}
