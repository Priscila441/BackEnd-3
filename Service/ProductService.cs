using AutoMapper;
using Datass.Repository.Interfaces;
using Models.Entity;
using Models.Entity.Dtos.Product;
using Service.Interfaces;


namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductGetDto>> BringAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            if (products == null) return null!;

            return _mapper.Map<IEnumerable<ProductGetDto>>(products);
        }

        public async Task<ProductGetDto> BringOneAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return null!;
            
            return _mapper.Map<ProductGetDto>(product);
        }

        public async Task<ProductGetDto> CreateAsync(ProductPostDto productPostDto)
        {
            if (string.IsNullOrWhiteSpace(productPostDto.NameProduct)) 
                throw new ArgumentException("El nombre del producto no puede estar vacío");
            if (productPostDto.Price <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0.");
            if (productPostDto.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");
            var categoryExists = await _unitOfWork.Categories.GetByIdAsync(productPostDto.CategoryId);
            if (categoryExists == null)
                throw new Exception("La categoría seleccionada no existe.");

            var productEntity = _mapper.Map<Product>(productPostDto);
            await _unitOfWork.Products.AddAsync(productEntity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProductGetDto>(productEntity);
        }

        public async Task<bool> ChangeAsync(int id, ProductPutDto productPutDto)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
            if (existingProduct == null)
                return false;

            if (string.IsNullOrWhiteSpace(productPutDto.NameProduct))
                throw new ArgumentException("El nombre del producto no puede estar vacío");
            if (productPutDto.Price <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0.");
            if (productPutDto.Stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");
            var categoryExists = await _unitOfWork.Categories.GetByIdAsync(productPutDto.CategoryId);
            if (categoryExists == null)
                throw new Exception("La categoría seleccionada no existe.");

            _mapper.Map(productPutDto, existingProduct);
            await _unitOfWork.Products.Update(existingProduct);
            await _unitOfWork.SaveAsync();
            return true;
        }
         
        public async Task<bool> DeleteAsync(int id)
        {
            var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
            if (existingProduct == null)
                return false;

            await _unitOfWork.Products.Delete(existingProduct);
            await _unitOfWork.SaveAsync();
            return true;
        }

    }
}
