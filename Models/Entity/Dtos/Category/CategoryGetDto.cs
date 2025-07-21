using Models.Entity.Dtos.Product;


namespace Models.Entity.Dtos.Category
{
    public class CategoryGetDto
    {
        public int IdCategory { get; set; }
        public required string NameCategory { get; set; }
        public List<ProductGetSimpleDto>? Products { get; set; }
    }
}
