using AutoMapper;
using Datass.Repository.Interfaces;
using Models.Entity;
using Models.Entity.Dtos.Order;
using Models.Entity.Enums;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<OrderGetDto>> BringAllAsync() {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            if (orders == null) return null!;
            return _mapper.Map<IEnumerable<OrderGetDto>>(orders);
        }

        public async Task<OrderGetDto> BringOneAsync(int id) {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null) return null!;
            return _mapper.Map<OrderGetDto>(order);
        }

        public async Task<bool> CreateOrder(OrderPatchPaymethod dtoPay) {

            var cartExist = await _unitOfWork.Carts.GetActiveCartAsync() ?? throw new ArgumentException("No existe ningún carrito activo");

            if (cartExist.CartDetail == null || !cartExist.CartDetail.Any()) throw new InvalidOperationException("El carrito no tiene productos");

            if (!Enum.IsDefined(typeof(PaymentMethod), dtoPay.PaymentMethod)) throw new ArgumentException("Método de pago no válido");


            var order = new Order
            {
                UserId = dtoPay.UserId,
                CartID = cartExist.IdCart,
                paymentMethod = dtoPay.PaymentMethod
            };

            foreach (var item in cartExist.CartDetail) {
                var orderDetail = new OrderDetail
                {
                    
                    ProductName = item.Product.NameProduct,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                };
                order.OrderDetails.Add(orderDetail);
            }

            cartExist.IsActive = false;
            order.CalculateTotal();

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id) {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null) return false;
            await _unitOfWork.Orders.Delete(order);
            await _unitOfWork.SaveAsync();
            return true;           
        }

    }
}
