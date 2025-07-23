using AutoMapper;
using Datass.Repository.Interfaces;
using Models.Entity.Dtos.Cart;
using Models.Entity.Dtos.CartDetailProduct;
using Models.Entity;


using Service.Interfaces;


namespace Service
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CartGetDto> addProductToCartAsync(CartDetailPostDto dto) {
            //buscar carrito activo, si no hay lo crea
            var cart = await _unitOfWork.Carts.GetActiveCartAsync();
            if (cart == null) 
            {
                cart = new Cart { IsActive = true };
                await _unitOfWork.Carts.AddAsync(cart);
                await _unitOfWork.SaveAsync();
            }

            //obtener producto
            var product = await _unitOfWork.Products.GetByIdAsync(dto.ProductId) 
                ?? throw new ArgumentException("Producto no encontrado");
            //si el producto ya está en el cartdetail entonces solo cambio la quantity con el post
            //crear cartdetail con subtotal
            var subtotal = product.Price * dto.Quantity;
            var cartdetail = _mapper.Map<CartDetailProduct>(dto);
            cartdetail.CartId = cart.IdCart;
            cartdetail.SubTotal = subtotal;

            await _unitOfWork.CartDetails.AddAsync(cartdetail);

            //actualizar total
            cart.Total += subtotal;
            await _unitOfWork.Carts.Update(cart);

            await _unitOfWork.SaveAsync();

            //return Cart-Dto con el detail incluido
            var updateCart = await _unitOfWork.Carts.GetActiveCartAsync();
            var result = _mapper.Map<CartGetDto>(updateCart);
            return result;
        }
    }
}
