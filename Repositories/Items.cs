using Catalog.Data;
using Catalog.DTOs;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Repositories
{
    public class Items: IItemsRepository
    {
        private readonly ApplicationDbContext context;

        public Items(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CreateItemAsync(Item item)
        {
            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(Item item)
        {
            context.Items.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await context.Items.AsNoTracking().FirstOrDefaultAsync(Item => Item.Id == id);
            
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await context.Items.ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            context.Items.Update(item);
            await context.SaveChangesAsync();

        }
    }
}
