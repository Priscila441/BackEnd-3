
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Entity.Dtos.Product
{
    public class ProductGetSimpleDto
    {
        [Required]
        [StringLength(20)]
        public required string NameProduct { get; set; }

        [StringLength(100)]
        [Url(ErrorMessage = "El campo debe ser una URL válida.")]
        public string? ImagesUrl { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }

    }
}
