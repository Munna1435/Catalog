using Catalog.Data;
using Catalog.DTOs;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Repositories
{
    public class Items: IItemsRepository
    {
        private readonly List<Item> items = new List<Item>()
        {
            new Item() { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedAt = DateTimeOffset.UtcNow },
            new Item() { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedAt = DateTimeOffset.UtcNow },
            new Item() { Id = Guid.NewGuid(), Name = "Bronze Sheild", Price = 18, CreatedAt = DateTimeOffset.UtcNow }
        };
        private readonly ApplicationDbContext context;

        public Items(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void CreateItem(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
        }

        public void DeleteItem(Item item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
        }

        public Item GetItem(Guid id)
        {
            return context.Items.AsNoTracking().FirstOrDefault(Item => Item.Id == id);
            
        }

        public IEnumerable<Item> GetItems()
        {
            return context.Items.ToList();
        }

        public void UpdateItem(Item item)
        {
            context.Items.Update(item);

            context.SaveChanges();

        }
    }
}
