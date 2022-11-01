using ITCPBackend.Data;
using ITCPBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITCPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BussinussViewController : ControllerBase
    {
        private readonly ITCPBackendContext _context;

        public BussinussViewController(ITCPBackendContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BussinessType>>> GetbussinessView()
        {
            var BussinussView = from j in _context.bussinessTypes
                                from p in _context.clients.Where(m => m.Id == j.ClientId).DefaultIfEmpty()
                                select new BussinessView
                                {
                                    Id = j.Id,
                                    ClientId = j.ClientId,
                                    ClientName = p.Name,
                                    Name = p.Name,
                                };
            return Ok(BussinussView);
        }
    }
}
