using System.ComponentModel.DataAnnotations;

namespace Catalog.Entities
{
    public record Item
    {
        public Guid Id { get; init; }
        [Required, StringLength(maximumLength:150)]
        public string Name { get; init; }
        public int Price { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
    }
}
