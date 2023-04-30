using System;
using CleaningService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using System.Linq;

namespace CleaningService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
		private readonly CleaningServiceContext _context;

		public ServiceController(CleaningServiceContext context)
		{
			_context = context;
			_context.Database.EnsureCreated();
		}

        [HttpGet("All")]
        public ActionResult GetServices()
		{
			// var services = string.Join(",", _context.Services.Select(x => x.name).ToList<string>());
			var services = _context.Services.ToList<Service>();
			if(services is null)
			{
				return NoContent();
			}
            return Ok(services);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateService(Service service)
		{
			_context.Services.Update(service);
			await _context.SaveChangesAsync();

			return CreatedAtAction(
				"GetServices",
				new { id = service.id }, service);
		}
		
		[HttpPost("Add")]
		public async Task<ActionResult> AddService([FromBody]Service service)
		{
			_context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetServices",
                new { id = service.id },
                service);

        }

		[HttpDelete("DeleteByID")]
		public async Task<ActionResult> DeleteService([FromBody]int id)
		{
			if (!_context.Services.Any(x => x.id == id))
			{
				return NotFound($"Index {id} Not Found.");
			}

			try
			{
				Service service = _context.Services.First(x => x.id == id);
				_context.Services.Remove(service);
				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message.ToString());
			}
			return Ok("Deleted.");
		}
	}
}

