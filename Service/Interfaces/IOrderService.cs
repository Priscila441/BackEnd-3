using Models.Entity.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderGetDto>> BringAllAsync();
        Task<OrderGetDto> BringOneAsync(int id);
        Task<bool> CreateOrder(OrderPatchPaymethod dtoPay);
        Task<bool> DeleteAsync(int id);

    }
}
