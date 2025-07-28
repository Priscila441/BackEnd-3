using Models.Entity.Enums;


namespace Models.Entity.Dtos.Product
{
    public class ProductGetDto
    {
        public int IdProduct { get; set; }
        public required string NameProduct { get; set; }
        public string? Description { get; set; }
        public string? ImagesUrl { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public StateProduct stateProduct { get; set; } = StateProduct.Available;
        public int CategoryId { get; set; }
    }
}
