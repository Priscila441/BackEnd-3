using AutoMapper;
using Models.Entity;
using Models.Entity.Dtos.Category;
using Models.Entity.Dtos.Product;
using Models.Entity.Dtos.CartDetailProduct;
using Models.Entity.Dtos.Cart;

namespace Models
{
    public class Mappings : Profile
    {
        public Mappings() {
            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductPostDto, Product>();
            CreateMap<ProductPutDto, Product>();

            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();

            CreateMap<CartDetailPostDto, CartDetailProduct>();
            CreateMap<CartDetailProduct, CartDetailGetDto>();
            CreateMap<CartDetailProduct, CartDetailSimpleDto>();

            CreateMap<Cart, CartGetDto>();
        }

    }
}
