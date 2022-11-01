using ITCPBackend.Data;
using ITCPBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITCPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITCPBackendContext _dbcontext;
        public UsersController(ITCPBackendContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetUser(int id = 0)
        {
            var UsersList = _dbcontext.Users.Where(m => id != 0 ? m.Id == id : true).ToList();
            return Ok(UsersList);
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateUser(Users user)
        {
            if(user.Id != 0)
            {
                //Users userExist = _dbcontext.Users.Where(m => m.Id == user.Id).ToList();
                user.ModifyBy = "system";
                user.CreatedDate = DateTime.Now;
                _dbcontext.Users.Update(user);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                user.CreatedBy = "System";
                user.CreatedDate = DateTime.Now;
                _dbcontext.Users.Add(user);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
