using BillLibrary.Modal;
using BillLibrary.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepo repo;
        public UserController(IUserRepo userRepo)
        {
            repo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUserDetails()
        {
            List<User> users = await repo.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("ByUserId/{userid}")]
        public async Task<ActionResult> GetUser(int userid)
        {
            try
            {
                User user = await repo.GetByUserId(userid);
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(User user)
        {
            try
            {
                await repo.InsertUser(user);
                return Created($"api/User/{user.UserId}", user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{userid}")]
        public async Task<ActionResult> Update(int userid, User user)
        {
            try
            {
                await repo.UpdateUser(userid, user);
                return Ok(user);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        [HttpDelete("{userid}")]
        public async Task<ActionResult> Delete(int userid)
        {
            try
            {
                await repo.DeleteUser(userid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByUserName/{userName}")]
        public async Task<ActionResult> GetByUserName(string userName)
        {
            try
            {
                User user = await repo.GetByUserName(userName);
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
