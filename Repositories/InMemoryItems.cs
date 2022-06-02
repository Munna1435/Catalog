using Catalog.DTOs;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Repositories
{
    public class InMemoryItems: IInMemoryItems
    {
        private readonly List<Item> items = new List<Item>()
        {
            new Item() { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedAt = DateTimeOffset.UtcNow },
            new Item() { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedAt = DateTimeOffset.UtcNow },
            new Item() { Id = Guid.NewGuid(), Name = "Bronze Sheild", Price = 18, CreatedAt = DateTimeOffset.UtcNow }
        };

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void DeleteItem(Guid id)
        {
            int index = items.FindIndex(item => item.Id == id); 
            items.RemoveAt(index);
        }

        public Item GetItem(Guid id)
        {
            return items.FirstOrDefault(Item => Item.Id == id);
            
        }

        public IEnumerable<Item> GetItems()
        {
            return items.ToList();
        }

        public void UpdateItem(Item item)
        {
            int index = items.FindIndex(Item => Item.Id == item.Id);
            items[index] = item;
        }
    }
}
