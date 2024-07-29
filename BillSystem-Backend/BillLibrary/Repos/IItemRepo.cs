using BillLibrary.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Repos
{
    public interface IItemRepo
    {
        Task<List<Items>> GetAllItems();
        Task<Items> GetByItemId(int itemId);
        Task InsertItem(Items Item);
        Task UpdateItem(int itemId, Items Item);
        Task DeleteItem(int itemId);
      //  Task<List<Items>> GetItemsByuserId(int userId);
    }
}
