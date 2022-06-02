using System.ComponentModel.DataAnnotations;

namespace Catalog.DTOs
{
    public record CreateItemDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 100)]
        public int Price { get; init; }
    }
}
