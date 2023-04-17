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
    public class CustomerController : Controller
    {
        private readonly CleaningServiceContext _context;

        public CustomerController(CleaningServiceContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: api/values
        [HttpGet("All")]
        public ActionResult GetAllCustomers()
        {
            if(_context.Customers.Count() > 0)
            {
                return Ok(_context.Customers.ToList());
            }
            return Content("No Customers");
        }

        // GET api/values/5
        [HttpGet("ByID")]
        public ActionResult GetCustomerByID([FromBody]int id)
        {
            if(_context.Customers.Any(x => x.id == id))
            {
                return Ok(_context.Customers.First(x => x.id == id));
            }

            return Content($"No Customer with ID {id}");
        }

        [HttpPost("AddCustomerNote")]
        public async Task<ActionResult> AddCustomerNote([FromBody]int customerID, CustomerNote customerNote)
        {
            if(!_context.Customers.Any(x => x.id == customerID))
            {
                return Content($"No Customer with ID {customerID}");
            }

            // Assign Customer to note
            customerNote.customer = _context.Customers.Find(customerID);

            // Assign Note to Customer
            _context.Customers.Find(customerID)?.CustomerNotes.Add(customerNote);

            // Add to CustomerNote Collection
            _context.CustomerNotes.Add(customerNote);
            await _context.SaveChangesAsync();

            return Ok($"Customer Note Added to {customerNote.customer?.ToString()}");
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

