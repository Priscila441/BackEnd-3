using Models.Entity.Dtos.Product;

using System.ComponentModel.DataAnnotations;


namespace Models.Entity.Dtos.Category
{
    public class CategoryPostDto
    {
        [Required]
        [StringLength(20)]
        public required string NameCategory { get; set; }
        public List<ProductGetSimpleDto>? Products { get; set; }
    }
}
