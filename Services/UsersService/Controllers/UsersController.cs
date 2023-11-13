using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersService.BusinessLogic;
using UsersService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusinessLogic _userBusinessLogic;

        public UsersController(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }

        // GET: api/<UsersController>
        [HttpGet("allUsers")]
        public async Task<List<User>> Get()
        {
            return await _userBusinessLogic.GetAsync();
        }


        // POST api/<UsersController>
        [HttpPost("CreateUser")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await _userBusinessLogic.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> AddToUserlist(string id, [FromBody] string role)
        {
            await _userBusinessLogic.AddToUsersAsync(id, role);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            await _userBusinessLogic.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("AuthanticateUser")]
        [Authorize]
        public IActionResult AuthanticateUser([FromBody] User user)
        {
            var authUser = _userBusinessLogic.AuthanticateUser(user.Username, user.Password);
            if (authUser != null)
            {
                return Ok(authUser);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
