using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class Cart
    {
        [Key]
        public int IdCart { get; set; }
        public DateTime DateTime { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public bool IsActive { get; set; } = true;
        public List<CartDetailProduct> cartDetail { get; set; } = null!;
    }
}
