using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController :ControllerBase
    {
        private readonly DataContext _Context;

        public UsersController(DataContext dataContext)
        {
            _Context = dataContext;
        }
        [HttpGet]
        public async Task< ActionResult<IEnumerable<AppUser>>>GetUsers()
        {
            var users = await _Context.Users.ToListAsync();
            return users;
        }
          [HttpGet("{id}")]
          public async Task <ActionResult<AppUser>>GetUser(int id)
          {
             return await _Context.Users.FindAsync(id);
            
          }
    }
}