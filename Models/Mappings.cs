using AutoMapper;
using Models.Entity;
using Models.Entity.Dtos.Category;
using Models.Entity.Dtos.Product;

namespace Models
{
    public class Mappings : Profile
    {
        public Mappings() {
            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductPostDto, Product>();
            CreateMap<ProductPutDto, Product>();

            CreateMap<Category, CategoryPostDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();
        }

    }
}
