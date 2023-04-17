using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleaningService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleaningService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly CleaningServiceContext _context;

        public AdminController(CleaningServiceContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        // GET: api/values
        [HttpGet("All")]
        public ActionResult GetAdmins()
        {
            return Ok(_context.Admins.ToList<Admin>());
        }

        // GET api/values/5
        [HttpGet("ByID")]
        public ActionResult GetAdmin([FromBody]int id)
        {
            if(_context.Admins.Any(x => x.id == id))
            {
                return Ok(_context.Admins.Find(id));
            }
            return NoContent();
        }

        // POST api/values
        [HttpPost("Add")]
        public async Task<ActionResult> AddAdmin([FromBody]Admin admin)
        {
            try
            {
                _context.Admins.Add(admin);
                await _context.SaveChangesAsync();

                return CreatedAtAction(
                    "GetAdmins",
                    new { id = admin.id },
                    admin
                    );
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Remove")]
        public async Task<ActionResult> DeleteAdmin([FromBody]int id)
        {
            if(_context.Admins.Any(x => x.id == id))
            {
                var admin = _context.Admins.First(x => x.id == id);
                _context.Admins.Remove(admin);

                await _context.SaveChangesAsync();

                return Ok($"Administrator: {admin.ToString()} - REMOVED.");
            }
            return Content("No Administrator with that ID");
        }
    }
}

