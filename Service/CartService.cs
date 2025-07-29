using AutoMapper;
using Datass.Repository.Interfaces;
using Models.Entity.Dtos.Cart;
using Models.Entity.Dtos.CartDetailProduct;
using Models.Entity;


using Service.Interfaces;
using System.Reflection.Metadata.Ecma335;


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

        public async Task<CartGetDto> BringAllCarts() {
            var cart = await _unitOfWork.Carts.GetActiveCartAsync();
            if (cart == null) throw new ArgumentException("El carrito está vacío");
            cart.ReCalculateTotal();
            return _mapper.Map<CartGetDto>(cart);
        }


        public async Task<CartGetDto> AddProductToCartAsync(CartDetailPostDto dto)
        {
            // Buscar carrito activo, si no hay, lo crea
            var cart = await _unitOfWork.Carts.GetActiveCartAsync();
            if (cart == null)
            {
                cart = new Cart { IsActive = true };
                await _unitOfWork.Carts.AddAsync(cart);
                await _unitOfWork.SaveAsync(); // Guardamos para que el carrito tenga Id y pueda asociarse al detalle
            }

            // Obtener producto
            var product = await _unitOfWork.Products.GetByIdAsync(dto.ProductId)
                ?? throw new ArgumentException("Producto no encontrado");

            // Buscar si ya existe ese producto en el cartdetail
            var existingDetail = await _unitOfWork.CartDetails.GetByCartAndProductIdAsync(dto.ProductId, cart.IdCart);

            if (existingDetail != null)
            {
                // Si existe, actualizar cantidad y subtotal
                existingDetail.Quantity += dto.Quantity;
                existingDetail.UnitPrice = product.Price;
                existingDetail.ReCalculateSubTotal();
                
                await _unitOfWork.CartDetails.Update(existingDetail);
            }
            else
            {
                // Si no existe, crear nuevo detalle
                var subtotal = product.Price * dto.Quantity;
                var cartdetail = _mapper.Map<CartDetailProduct>(dto);
                cartdetail.CartId = cart.IdCart;
                cartdetail.SubTotal = subtotal;

                await _unitOfWork.CartDetails.AddAsync(cartdetail);
                cart.CartDetail.Add(cartdetail);
            }

            // Volver a consultar el carrito con sus detalles para recalcular total
            
            await _unitOfWork.Carts.Update(cart);
            await _unitOfWork.SaveAsync();

            // Devolver carrito actualizado
            var result = _mapper.Map<CartGetDto>(cart);
            return result;
        }

        public async Task<bool> DeleteCart() {
            var cartExist = await _unitOfWork.Carts.GetActiveCartAsync();
                if (cartExist == null) return false;

            await _unitOfWork.Carts.Delete(cartExist);
            await _unitOfWork.SaveAsync();
            return true;
        }



    }
}

