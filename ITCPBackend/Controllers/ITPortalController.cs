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
        #region Get MDA LIst
        [HttpGet]
        public async Task<IActionResult> MDAUsersList()
        {
            var EntryList = _dbcontext.clients.Where(m => m.Role == Constants.ClientRoleInt.MasterMDA).ToList();
            return Ok(EntryList);
        }
        #endregion
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
        #region ITPortal Tables Data
        [HttpGet]
        public IActionResult ProjectProgressList(int status)
        {
            try
            {
                var JoinProject = (from project in _dbcontext.projects.Where(m => m.Status >= status)
                                   from detail in _dbcontext.project_details.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                   select new CompeteProjectDto
                                   {
                                       Id = project.Id,
                                       MDA = project.MDA,
                                       BudgetCode = project.BudgetCode,
                                       MDASector = project.MDASector,
                                       ProjectName = detail.ProjectName,
                                       ProjectDescription = detail.ProjectDescription,
                                       RejectNotes = project.RejectNotes,
                                       ProjectClassification = detail.ProjectClassification,
                                       ProjectObjectives = detail.ProjectObjectives,
                                       ProjectStatus = project.Status,
                                       ProjectCreated = project.CreatedDate,
                                       projectLevel = project.Status == (int)Constants.ProjectStatus.MDApprove ? "Level 1" :
                                                                      project.Status == (int)Constants.ProjectStatus.SectApprove ? "Level 2" :
                                                                      project.Status == (int)Constants.ProjectStatus.Comeetee ? "Level 3" :
                                                                      project.Status == (int)Constants.ProjectStatus.SectReject ? "Level 0" : ""
                                   }).ToList();
                return Ok(JoinProject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ProjectFiterProgressList(int status, DateTime? Fromdate, DateTime? Todate, int entryUserId)
        {
            try
            {
                //if(Fromdate != null && Todate != null)
                //{
                //    FromDate = DateTime.Parse(Fromdate);
                //    ToDate = DateTime.Parse(Todate);
                //}
                var JoinProject = (from project in _dbcontext.projects.Where(m => m.Status >= status && m.CreatedDate.Date >= Fromdate && m.CreatedDate.Date <= Todate && m.ClientId == entryUserId)
                                   from detail in _dbcontext.project_details.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                   select new CompeteProjectDto
                                   {
                                       Id = project.Id,
                                       MDA = project.MDA,
                                       BudgetCode = project.BudgetCode,
                                       MDASector = project.MDASector,
                                       ProjectName = detail.ProjectName,
                                       ProjectDescription = detail.ProjectDescription,
                                       RejectNotes = project.RejectNotes,
                                       ProjectClassification = detail.ProjectClassification,
                                       ProjectObjectives = detail.ProjectObjectives,
                                       ProjectStatus = project.Status,
                                       ProjectCreated = project.CreatedDate,
                                       projectLevel = project.Status == (int)Constants.ProjectStatus.MDApprove ? "Level 1" :
                                                                      project.Status == (int)Constants.ProjectStatus.SectApprove ? "Level 2" :
                                                                      project.Status == (int)Constants.ProjectStatus.Comeetee ? "Level 3" : ""
                                   }).ToList();
                return Ok(JoinProject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
