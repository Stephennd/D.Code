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
    [ApiController]
    public class AdminStatesController : Controller
    {
        public readonly CleaningServiceContext _context;

        public AdminStatesController(CleaningServiceContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        
        [HttpGet("All")]
        public ActionResult GetAdminStates()
        {
            if (_context.AdminStates is not null)
            {
                return Ok(_context.AdminStates);
            }
            return NoContent();
        }

    }
}

