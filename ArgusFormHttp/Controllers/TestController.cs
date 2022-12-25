using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgusFormHttp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext ctx;

        public TestController(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpPost("SaveUser")]
        public async Task<IActionResult> SaveUser(User user)
        {
            if (user == null) 
                return BadRequest();

             await this.ctx.Users.AddAsync(user);
             await this.ctx.SaveChangesAsync();
             return Ok( new {
                 success= true, 
                 message = "Registration Successful."
             });

        }
    }
}
