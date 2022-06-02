using System.ComponentModel.DataAnnotations;

namespace Catalog.DTOs
{
    public record UpdateItemDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 100)]
        public int Price { get; init; }
    }
}
