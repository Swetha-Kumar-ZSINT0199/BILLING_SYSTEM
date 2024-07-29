using BillLibrary.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Repos
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetByUserId(int userId);
        Task<User> GetByUserName(string userName);
        Task InsertUser(User user);
        Task UpdateUser(int userid, User user);
        Task DeleteUser(int userid);
    }
}
