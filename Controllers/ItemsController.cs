using Catalog.DTOs;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ItemDto>> GetItems()
        {
            return Ok((await repository.GetItemsAsync()).Select(item => item.AsDto()));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if(item == null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItem(CreateItemDto createItemDto)
        {
            var item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                CreatedAt = DateTimeOffset.UtcNow
            };
            await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItem), new {Id = item.Id}, item.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDto>> UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await repository.GetItemAsync(id);
            if(existingItem is null)
            {
                return NotFound();
            }

            var item = existingItem with
            {
                Name = updateItemDto.Name,
                Price = updateItemDto.Price,
            };
            await repository.UpdateItemAsync(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(Guid id)
        {
            var item = await repository.GetItemAsync(id);
            if(item is null)
            {
                return NotFound();
            }
            await repository.DeleteItemAsync(item);
            return NoContent();
        }
    }
}
