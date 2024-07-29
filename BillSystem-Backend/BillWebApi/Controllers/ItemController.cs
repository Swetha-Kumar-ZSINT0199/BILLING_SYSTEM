using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillLibrary.Repos;
using BillLibrary.Modal;
namespace BillWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        IItemRepo repo;
        public ItemController(IItemRepo itemRepo)
        {
            repo = itemRepo;   
        }
        [HttpGet]
        public async Task<ActionResult> GetAllItems() 
        {
            List<Items> items = await repo.GetAllItems();
            return Ok(items);
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Items item)
        {
            try
            {
                await repo.InsertItem(item);
                return Created($"api/Items/{item.ItemId}", item);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{itemId}")]
        public async Task<ActionResult> Update(int itemId,Items item)
        {
            try
            {
              await repo.UpdateItem(itemId, item);
              return Ok(item);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{itemId}")]
        public async Task<ActionResult> Delete(int itemId)
        {
            try
            {
                await repo.DeleteItem(itemId);
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByItemId/{itemId}")]
        public async Task<ActionResult> GetOneItem(int itemId)
        {
            try
            {
                Items items = await repo.GetByItemId(itemId);
                return Ok(items);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
