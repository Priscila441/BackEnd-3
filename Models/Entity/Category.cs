
using System.ComponentModel.DataAnnotations;


namespace Models.Entity
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }

        public required string NameCategory { get; set; }

        public List<Product>? Products { get; set; }
    }
}

