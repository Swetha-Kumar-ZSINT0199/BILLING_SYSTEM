using BillLibrary.Modal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Repos
{
    public class BillRepo : IBillRepo
    {
        BillDBContext dbContext;
        public BillRepo(BillDBContext billDBContext)
        {
            dbContext = new BillDBContext();
        }
        public async Task DeleteBill(int billId)
        {
            try
            {
                Bill billtodelete = await GetBillById(billId);
                dbContext.Bills.Remove(billtodelete);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Bill>> GetAllBill()
        {
            try
            {
                List<Bill> bills = await dbContext.Bills.ToListAsync();
                return bills;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bill> GetBillById(int billId)
        {
            try
            {
                Bill bills = await (from u in dbContext.Bills where u.BillId == billId select u).FirstAsync();
                return bills;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bill> GetBillByUserId(int userId)
        {
            try
            {
                Bill bill = await (from u in dbContext.Bills where u.UserId == userId select u).FirstAsync();
                return bill;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
    }
}

        public async Task InsertBill(Bill bills)
        {
            try
            {
                await dbContext.Bills.AddAsync(bills);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateBill(int billId, Bill bill)
        {
            try
            {
                Bill updatebill = await GetBillByUserId(billId);
                updatebill.UserId = bill.UserId;
                updatebill.TotalItem =  bill.TotalItem;
                updatebill.TotalAmt = bill.TotalAmt;
                dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
