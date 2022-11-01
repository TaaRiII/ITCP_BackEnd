using ITCPBackend.Data;
using ITCPBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITCPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Client1Controller : Controller
    {
        private readonly ITCPBackendContext _context;
        public Client1Controller(ITCPBackendContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.clients.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClients(int id)
        {
            var clients = await _context.clients.FindAsync(id);

            if (clients == null)
            {
                return NotFound();
            }

            return clients;
        }
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetClients", new { id = client.Id }, client);
        }
    }
}
