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
        private readonly IInMemoryItems repository;

        public ItemsController(IInMemoryItems repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<ItemDto> GetItems()
        {
            return Ok(repository.GetItems().Select(item => item.AsDto()));
        }
        
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if(item == null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
            var item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                CreatedAt = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new {Id = item.Id}, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult<ItemDto> UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = repository.GetItem(id);
            if(existingItem is null)
            {
                return NotFound();
            }

            var item = existingItem with
            {
                Name = updateItemDto.Name,
                Price = updateItemDto.Price,
            };
            repository.UpdateItem(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Item> DeleteItem(Guid id)
        {
            var item = repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            repository.DeleteItem(id);
            return NoContent();
        }
    }
}
