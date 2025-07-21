
using System.ComponentModel.DataAnnotations;


namespace Models.Entity.Dtos.Category
{
    public class CategoryPutDto
    {
        [Required]
        [StringLength(20)]
        public required string NameCategory { get; set; }
    }
}
