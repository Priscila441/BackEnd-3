using AutoMapper;
using Datass.Repository.Interfaces;
using Models.Entity;
using Models.Entity.Dtos.Category;
using Models.Entity.Dtos.Product;
using Service.Interfaces;


namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryGetDto>> BringAllAsync() {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            if (categories == null) return null!;
            return _mapper.Map<IEnumerable<CategoryGetDto>>(categories);
        }

        public async Task<CategoryGetDto> BringOneAsync(int id) {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null) return null!;
            return _mapper.Map<CategoryGetDto>(category);
        }

        public async Task<CategoryGetDto> CreateAsync(CategoryPostDto category) {
            if (string.IsNullOrWhiteSpace(category.NameCategory))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío");
            
            var categoryEntity = _mapper.Map<Category>(category);
            await _unitOfWork.Categories.AddAsync(categoryEntity);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CategoryGetDto>(categoryEntity);
        }

        public async Task<bool> ChangeAsync(int id, CategoryPutDto category) {
            var categoryEntity = await _unitOfWork.Categories.GetByIdAsync(id);
            if (categoryEntity == null) return false;

            if (string.IsNullOrWhiteSpace(categoryEntity.NameCategory))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío");

            _mapper.Map(category, categoryEntity);
            await _unitOfWork.Categories.Update(categoryEntity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id) {
            var categoryEntity = await _unitOfWork.Categories.GetByIdAsync(id);
            if (categoryEntity == null) return false;

            await _unitOfWork.Categories.Delete(categoryEntity);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
