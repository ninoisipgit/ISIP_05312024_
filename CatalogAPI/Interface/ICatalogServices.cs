using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogAPI.Models;

public interface ICatalogService
{
    Task<IEnumerable<Catalog>> GetItemsAsync();
    Task<Catalog> GetItemAsync(int id);
    Task<Catalog> AddItemAsync(Catalog item);
    Task<Catalog> UpdateItemAsync(Catalog item);
}
