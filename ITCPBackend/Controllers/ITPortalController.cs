using AutoMapper;
using ITCPBackend.Data;
using ITCPBackend.DTOs;
using ITCPBackend.Helper;
using Microsoft.AspNetCore.Mvc;

namespace ITCPBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ITPortalController : Controller
    {
        private readonly ITCPBackendContext _dbcontext;
        public ITPortalController(ITCPBackendContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
        }
        #region Dashboard Graphies data
        [HttpGet]
        public IEnumerable<ChartData> GetProjectChartData()
        {
            var all = _dbcontext.projects.Where(m => m.Status != (int)Constants.ProjectStatus.Draft && m.Status != (int)Constants.ProjectStatus.Submit && m.Status != (int)Constants.ProjectStatus.MDAReject).Count();
            var sectRejected = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.SectReject).Count();
            var mdaApprove = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.MDApprove).Count();
            var sectApprove = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.SectApprove).Count();
            var commitee = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.Comeetee).Count();
            var data = new List<ChartData>
            {
                new ChartData { Key = "All", Value = all },
                new ChartData { Key = "New Project", Value = mdaApprove },
                new ChartData { Key = "Approved Secretariat", Value = sectApprove },
                new ChartData { Key = "Reject Secretariat", Value = sectRejected },
                new ChartData { Key = "Commitee", Value = commitee },
            };
            return data;
        }
        #endregion
    }
}
