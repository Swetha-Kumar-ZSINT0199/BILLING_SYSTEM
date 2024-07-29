using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillLibrary.Modal;
namespace BillLibrary.Repos
{
    public interface IOrderRepo
    {
        Task<List<Bill>> GetAllBill();
        Task InsertOrder(Order order);
        Task UpdateOrder(int orderId, Order order);
        Task DeleteOrder(int orderId);
        Task<Bill> GetOrderById(int billId);
        Task<Bill> GetBillByUserId(int userId);
    }
}
