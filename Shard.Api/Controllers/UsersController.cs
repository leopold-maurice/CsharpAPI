using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shard.Api.model;
using System.Text.RegularExpressions;

namespace Shard.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private List<User> _user;
        public UsersController([FromServices] List<User> u)
        {
            _user = u;
        }

        [HttpPut("{id}")]
        public ActionResult<User> CreateUser(string id,[FromBody] User user, [FromServices] Sector sector)
        {
            if(user.id != id || user.id == null || !(Regex.IsMatch(user.id, "^[a-zA-Z0-9_-]+$")))
            {
                return BadRequest();
            }
            else
            {
                User u = new User(user.id, user.pseudo, sector);
                _user.Add(u);
                return u;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> getUserById(string id)
        {
            foreach(User user in _user)
            {
                if(user.id == id)
                {
                    return user;
                }
            }
            return NotFound();
        }

    }
}
