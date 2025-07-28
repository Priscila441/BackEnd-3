using AutoMapper;
using Datass.Repository.Interfaces;
using Models.Entity;
using Models.Entity.Dtos.CartDetailProduct;
using Service.Interfaces;


namespace Service
{
    public class CartDetailService : ICartDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CartDetailGetDto> UpdateQuantityAsync(CartDetailPostDto dto)
        {
            var cartExist = await _unitOfWork.Carts.GetActiveCartAsync()
                ?? throw new ArgumentException("El carrito no existe");

            var product = await _unitOfWork.Products.GetByIdAsync(dto.ProductId)
                ?? throw new ArgumentException("El Producto no existe");

            var cartDetailExist = await _unitOfWork.CartDetails.GetByCartAndProductIdAsync(product.IdProduct, cartExist.IdCart)
                ?? throw new ArgumentException("El producto no está en el carrito");

            cartDetailExist.Quantity = dto.Quantity;
            cartDetailExist.UnitPrice = product.Price;
            cartDetailExist.ReCalculateSubTotal();

            await _unitOfWork.CartDetails.Update(cartDetailExist);

            cartExist.ReCalculateTotal();
            await _unitOfWork.Carts.Update(cartExist);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CartDetailGetDto>(cartDetailExist);
        }
    }
}
