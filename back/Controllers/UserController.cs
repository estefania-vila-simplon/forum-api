using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back.Models;
using back.Repositories.Interfaces;
using back.Services.Interfaces;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly forumdbContext _context;

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _context = new forumdbContext();
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        
        public IActionResult GetUsers()
        {
            return Ok(this._userService.GetAllUsers());
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok (user);
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (UserExists(id))
            {

                try
                {
                    _userService.Update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Problem ("Update failed");
                          
                }

            }
            else
            {
                return BadRequest();
            }                               


            return Ok("User modified");
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostUser(User user)
        {          
            try
            {
                _userService.Create(user);
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserId))
                {
                    return Conflict("User already exists");
                }
                else
                {
                    return Problem();
                }
            }

            return Ok("User created");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
           
            var user = _userService.GetById(id);
                
            if (user == null)
            {
                return NotFound();
            }

            _userService.Delete(user);
            
            return Ok("User deleted");
        }

        private bool UserExists(int id)
        {
            return _userService.GetById(id) != null;               
        }
    }
}
