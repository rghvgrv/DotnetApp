using Dotnet_Reddis.Service;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Reddis.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _itemService.GetItemAsync(id);
            return Ok(item);
        }
    }
}
