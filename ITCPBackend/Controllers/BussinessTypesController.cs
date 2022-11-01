using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITCPBackend.Data;
using ITCPBackend.Model;

namespace ITCPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BussinessTypesController : ControllerBase
    {
        private readonly ITCPBackendContext _context;

        public BussinessTypesController(ITCPBackendContext context)
        {
            _context = context;
        }

        // GET: api/BussinessTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BussinessType>>> GetbussinessTypes()
        {
            return await _context.bussinessTypes.ToListAsync();
        }

        // GET: api/BussinessTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BussinessType>> GetBussinessType(int id)
        {
            var bussinessType = await _context.bussinessTypes.FindAsync(id);

            if (bussinessType == null)
            {
                return NotFound();
            }

            return bussinessType;
        }

        // PUT: api/BussinessTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBussinessType(int id, BussinessType bussinessType)
        {
            if (id != bussinessType.Id)
            {
                return BadRequest();
            }

            _context.Entry(bussinessType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BussinessTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BussinessTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BussinessType>> PostBussinessType(BussinessType bussinessType)
        {
            _context.bussinessTypes.Add(bussinessType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBussinessType", new { id = bussinessType.Id }, bussinessType);
        }

        // DELETE: api/BussinessTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBussinessType(int id)
        {
            var bussinessType = await _context.bussinessTypes.FindAsync(id);
            if (bussinessType == null)
            {
                return NotFound();
            }

            _context.bussinessTypes.Remove(bussinessType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BussinessTypeExists(int id)
        {
            return _context.bussinessTypes.Any(e => e.Id == id);
        }
    }
}
