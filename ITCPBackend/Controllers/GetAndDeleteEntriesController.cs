using AutoMapper;
using ITCPBackend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITCPBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetAndDeleteEntriesController : Controller
    {
        private readonly ITCPBackendContext _dbcontext;
        public GetAndDeleteEntriesController(ITCPBackendContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult getProject()
        {
            return Ok(_dbcontext.projects.ToList());
        }
        [HttpGet]
        public IActionResult getProjectCosts()
        {
            return Ok(_dbcontext.project_costs.ToList());
        }
        [HttpGet]
        public IActionResult getProjectDetails()
        {
            return Ok(_dbcontext.project_details.ToList());
        }
        [HttpGet]
        public IActionResult getProjectDurations()
        {
            return Ok(_dbcontext.project_durations.ToList());
        }
        [HttpGet]
        public IActionResult getProjectScopes()
        {
            return Ok(_dbcontext.project_scopes.ToList());
        }
        [HttpGet]
        public IActionResult getProjectStrategy()
        {
            return Ok(_dbcontext.project_strategy_and_state.ToList());
        }
        [HttpPost]
        public IActionResult DelProject()
        {
            var List = _dbcontext.projects.ToList();
            foreach(var obj in List)
            {
                _dbcontext.projects.Remove(obj);
            }
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult DelProjectCosts()
        {
            var List = _dbcontext.project_costs.ToList();
            foreach (var obj in List)
            {
                _dbcontext.project_costs.Remove(obj);
            }
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult DelProjectDetails()
        {
            var List = _dbcontext.project_details.ToList();
            foreach (var obj in List)
            {
                _dbcontext.project_details.Remove(obj);
            }
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult DelProjectDurations()
        {
            var List = _dbcontext.project_durations.ToList();
            foreach (var obj in List)
            {
                _dbcontext.project_durations.Remove(obj);
            }
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult DelProjectScopes()
        {
            var List = _dbcontext.project_scopes.ToList();
            foreach (var obj in List)
            {
                _dbcontext.project_scopes.Remove(obj);
            }
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult DelProjectStrategy()
        {
            var List = _dbcontext.project_strategy_and_state.ToList();
            foreach (var obj in List)
            {
                _dbcontext.project_strategy_and_state.Remove(obj);
            }
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}
