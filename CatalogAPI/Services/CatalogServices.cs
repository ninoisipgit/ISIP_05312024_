using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogAPI.DataBase;
using CatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

public class CatalogService : ICatalogService
{
    private readonly DataBaseContext _context;

    public CatalogService(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Catalog>> GetItemsAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Catalog> GetItemAsync(int id)
    {
        return await _context.Items.FindAsync(id);
    }

    public async Task<Catalog> AddItemAsync(Catalog item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<Catalog> UpdateItemAsync(Catalog item)
    {
        var existingItem = await _context.Items.FindAsync(item.Id);
        if (existingItem == null)
        {
            return null;
        }

        existingItem.Name = item.Name;
        existingItem.Description = item.Description;
        existingItem.Category = item.Category;

        _context.Items.Update(existingItem);
        await _context.SaveChangesAsync();
        return existingItem;
    }
}
