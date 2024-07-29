using BillLibrary.Modal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Repos
{

    public class ItemRepo : IItemRepo
    {
      
        BillDBContext dbContext;
        public ItemRepo(BillDBContext billDBContext) 
        {
            dbContext = billDBContext;  
        }
        public async Task DeleteItem(int itemId)
        {
            try
            {
                Items itemtodelete = await GetByItemId(itemId);
                dbContext.Items.Remove(itemtodelete);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Items>> GetAllItems()
        {
            try
            {
                List<Items> items = await dbContext.Items.ToListAsync();
                return items;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Items> GetByItemId(int itemId)
        {
            try
            {
                Items items = await (from u in dbContext.Items where u.ItemId == itemId select u).FirstAsync();
                return items;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
/*
        public async Task<List<Items>> GetItemsByuserId(int userId)
        {
            try
            {
                List<Items> items=await (from u in dbContext.Items where u.Id == userId select u).ToListAsync();
                return items;
            }
            catch(Exception)
            {
                throw new Exception("User has bought any items");
            }
        }

    */
        public async Task InsertItem(Items Item)
        {
            try
            {
                await dbContext.Items.AddAsync(Item);
                await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateItem(int itemId, Items Item)
        {
            try
            {
                Items updateitem = await GetByItemId(itemId);
                updateitem.Name = Item.Name;
                updateitem.Qty = Item.Qty;
                updateitem.Price= Item.Price;
                dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
