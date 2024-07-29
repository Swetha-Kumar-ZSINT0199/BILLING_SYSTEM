using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillLibrary.Repos;
using BillLibrary.Modal;

namespace BillWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        IBillRepo repo;
        public BillController(IBillRepo billRepo)
        {
           repo = billRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBill()
        {
            List<Bill> bills = await repo.GetAllBill();
            return Ok(bills);
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Bill bill)
        {
            try
            {
                await repo.InsertBill(bill);
                return Created($"api/Bill/{bill.BillId}", bill);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{billId}")]
        public async Task<ActionResult> Update(int billId, Bill bill)
        {
            try
            {
                await repo.UpdateBill(billId, bill);
                return Ok(bill);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{billId}")]
        public async Task<ActionResult> Delete(int billId)
        {
            try
            {
                await repo.DeleteBill(billId);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByBillId/{billId}")]
        public async Task<ActionResult> GetOneBill(int billId)
        {
            try
            {
                Bill bills = await repo.GetBillById(billId);
                return Ok(bills);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
