using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleaningService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleaningService.Controllers
{
    [Route("api/[controller]")]
    public class SuperUserController : Controller
    {
        private readonly CleaningServiceContext _context;

        public SuperUserController(CleaningServiceContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        // GET: api/values
        [HttpGet("All")]
        public ActionResult GetSuperUser()
        {
            if (_context.SuperUsers.Count() == 0)
            {
                return NoContent();
            }
            return Ok(_context.SuperUsers.First(x => x.id == 1));
        }

        [HttpPut("UserName")]
        public async Task<ActionResult> UpdateUserName([FromBody]string val)
        {
            if (_context.SuperUsers.Find(1) is null)
            {
                return NoContent();
            }

            try
            {
                _context.SuperUsers.Find(1).userName = val;
                await _context.SaveChangesAsync();

                return Ok("Update Successful");
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPut("Password")]
        public async Task<ActionResult> UpdatePassword([FromBody]string val)
        {
            if(_context.SuperUsers.Find(1) is null)
            {
                return NoContent();
            }

            try
            {
                _context.SuperUsers.Find(1).credential = val;
                await _context.SaveChangesAsync();

                return Ok("Update Successful");
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }
        
    }
}

