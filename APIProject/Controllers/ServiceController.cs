using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Models;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly APIProjectDBContext _context;

        public ServiceController(APIProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Service
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> Getservices()
        {
          if (_context.services == null)
          {
              return NotFound();
          }
            return await _context.services.ToListAsync();
        }

        // GET: api/Service/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.services.FirstOrDefaultAsync(c => c.ServiceId == id);
            try
            {
                if (service == null)
                {
                    throw new Exception("Not Found, ServiceId does not exist");
                }
                return StatusCode(200, service);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            //if (_context.services == null)
            //{
            //    return NotFound();
            //}
            //var service = await _context.services.FindAsync(id);

            //if (service == null)
            //{
            //    return NotFound();
            //}

            //return service;

        }

        //// PUT: api/Service/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutService(int id, Service service)
        //{
        //    if (id != service.ServiceId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(service).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ServiceExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Service
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
          if (_context.services == null)
          {
              return Problem("Entity set 'APIProjectDBContext.services'  is null.");
          }
            _context.services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = service.ServiceId }, service);
        }

        // DELETE: api/Service/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (_context.services == null)
            {
                return NotFound();
            }
            var service = await _context.services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return (_context.services?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
