using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillLibrary.Modal;
using Microsoft.EntityFrameworkCore;

namespace BillLibrary.Repos
{
    public class UserRepo : IUserRepo
    {
        BillDBContext dbContext;
        public UserRepo(BillDBContext userRepo)
        {
            dbContext = userRepo;
        }

        public async Task DeleteUser(int userid)
        {
            try
            {
                User usertodelete = await GetByUserId(userid);
                dbContext.Users.Remove(usertodelete);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                List<User> users = await dbContext.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<User> GetByUserId(int userId)
        {
            try
            {
                User user = await (from u in dbContext.Users where u.UserId == userId select u).FirstAsync();
                return user;
            }
            catch
            {
                throw new Exception("Useri Id not Exists");
            }
        }

        public async Task<User> GetByUserName(string userName)
        {
            try
            {
                User user = await(from u in dbContext.Users where u.Email == userName select u).FirstAsync();
                return user;
            }
            catch (Exception)
            {
                throw new Exception("UserName doesn't exists");
            }
        }

        public async Task InsertUser(User user)
        {
            try
            {
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task UpdateUser(int userid, User user)
        {
            try
            {
                User updateuser = new User();
                updateuser.Name = user.Name;
                updateuser.Password = updateuser.Password;
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
