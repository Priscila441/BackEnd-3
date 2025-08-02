using Models.Entity.Dtos.OrderDetail;
using Models.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity.Dtos.Order
{
    public class OrderGetDto
    {
        public int IdOrder { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public StateOrder stateOrder { get; set; } = StateOrder.Pendiente;
        public PaymentMethod paymentMethod { get; set; } = PaymentMethod.MercadoPago;
        public int UserId { get; set; }
        public List<OrderDetailSimpleDto> OrderDetails { get; set; } = new List<OrderDetailSimpleDto>();
        public decimal Total { get; set; }


    }
}
