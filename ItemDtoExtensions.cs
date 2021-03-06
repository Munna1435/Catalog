using Catalog.DTOs;
using Catalog.Entities;

namespace Catalog
{
    public static class ItemDtoExtensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedAt = item.CreatedAt,
            };
        }
    }
}
