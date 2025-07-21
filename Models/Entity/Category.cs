
using System.ComponentModel.DataAnnotations;


namespace Models.Entity
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }

        [Required]
        [StringLength(20)]
        public required string NameCategory { get; set; }

        public List<Product>? Products { get; set; }
    }
}

