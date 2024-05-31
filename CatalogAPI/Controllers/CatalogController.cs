using CatalogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalog>>> GetItems()
        {
            var items = await _catalogService.GetItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Catalog>> GetItem(int id)
        {
            var item = await _catalogService.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> PostItem(Catalog item)
        {
            if (item == null)
            {
                return BadRequest("Catalog is null.");
            }
            var createdItem = await _catalogService.AddItemAsync(item);
            return Ok(createdItem);
        }

        [HttpPut]
        public async Task<IActionResult> PutItem(Catalog item)
        {
            var updatedItem = await _catalogService.UpdateItemAsync(item);
            if (updatedItem == null)
            {
                return NotFound();
            }
            return Ok(updatedItem);
        }
    }
}
