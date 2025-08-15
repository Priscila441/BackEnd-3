using AutoMapper;
using Models.Entity;
using Models.Entity.Dtos.Category;
using Models.Entity.Dtos.Product;
using Models.Entity.Dtos.CartDetailProduct;
using Models.Entity.Dtos.Cart;
using Models.Entity.Dtos.User;
using Models.Entity.Dtos.Order;
using Models.Entity.Dtos.OrderDetail;

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

            CreateMap<User, UserGetDto>();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();

            CreateMap<Order, OrderGetDto>();
            CreateMap<Order, OrderPatchPaymethod>();

            CreateMap<OrderDetail, OrderDetailSimpleDto>();
        }

    }
}
