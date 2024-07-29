using BillLibrary.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Repos
{
    public interface IBillRepo
    {
        Task<List<Bill>> GetAllBill();
        Task InsertBill(Bill bill);
        Task UpdateBill(int billId, Bill bill);
        Task DeleteBill(int billId);
        Task<Bill> GetBillById(int billId);
        Task<Bill>GetBillByUserId(int userId);
    }
}
