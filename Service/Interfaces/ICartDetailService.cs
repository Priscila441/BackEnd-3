using Models.Entity.Dtos.CartDetailProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICartDetailService
    {
        Task<CartDetailGetDto> UpdateQuantityAsync(CartDetailPostDto dto);

    }
}
