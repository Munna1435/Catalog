using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Repositories
{
    public interface IInMemoryItems
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);

        void DeleteItem(Guid id);


    }
}
