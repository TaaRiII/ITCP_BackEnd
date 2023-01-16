using ITCPBackend.Data;
using ITCPBackend.DTOs;
using ITCPBackend.Helper;
using ITCPBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Nodes;

namespace ITCPBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly ITCPBackendContext _dbcontext;
        public ProjectController(ITCPBackendContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        #region
        [HttpPost]
        public async Task<IActionResult> AddUpdateProject(ProjectModel project)
        {
            var token = new JwtSecurityToken(project.accesstoken);
            var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
            Client getClient = _dbcontext.clients.Find(claimsId);
            var obj = _dbcontext.projects.Where(m => m.Id == project.Id).FirstOrDefault();
            if (project.Id != 0)
            {

                Project pro = new Project()
                {
                    MDA = project.MDA,
                    BudgetCode = project.BudgetCode,
                    //MDASector = project.MDASector,
                    ModifiedBy = getClient.Username,
                    ModifiedDate = DateTime.Now,
                };
                _dbcontext.projects.Add(pro);
                await _dbcontext.SaveChangesAsync();
                ProjectDetail prodetail = new ProjectDetail()
                {
                    ProjectName = project.ProjectName,
                    ProjectClassification = project.ProjectClassification,
                    ProjectDescription = project.ProjectDescription,
                    ProjectObjectives = project.ProjectObjectives,
                    ProjectId = pro.Id,
                };
                _dbcontext.project_details.Update(prodetail);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                Project pro = new Project()
                {
                    MDA = project.MDA,
                    BudgetCode = project.BudgetCode,
                    //MDASector = project.MDASector,
                    CreatedBy = getClient.Username,
                    CreatedDate = DateTime.Now,
                    ClientId = getClient.Id,
                };
                _dbcontext.projects.Add(pro);
                await _dbcontext.SaveChangesAsync();
                ProjectDetail prodetail = new ProjectDetail()
                {
                    ProjectName = project.ProjectName,
                    ProjectClassification = project.ProjectClassification,
                    ProjectDescription = project.ProjectDescription,
                    ProjectObjectives = project.ProjectObjectives,
                    ProjectId = pro.Id,
                };
                _dbcontext.project_details.Update(prodetail);
                await _dbcontext.SaveChangesAsync();
                return Ok(pro.Id);
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> AddUpdateProjectCost(ProjectCostModel project)
        //{
        //    var obj = _dbcontext.project_costs.Where(m => m.Id == project.Id).FirstOrDefault();
        //    if (project.Id != 0)
        //    {
        //        ProjectCost pro = new ProjectCost()
        //        {
        //            Description = project.Description,
        //            Amount = project.Amount,
        //        };
        //        _dbcontext.project_costs.Update(pro);
        //        await _dbcontext.SaveChangesAsync();
        //        return Ok();
        //    }
        //    else
        //    {
        //        ProjectCost pro = new ProjectCost()
        //        {
        //            Description = project.Description,
        //            Amount = project.Amount,
        //        };
        //        _dbcontext.project_costs.Add(pro);
        //        await _dbcontext.SaveChangesAsync();
        //        return Ok();
        //    }
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddUpdateProjectDetail(ProjectDetailModel project)
        //{
        //    var obj = _dbcontext.project_details.Where(m => m.Id == project.Id).FirstOrDefault();
        //    if (project.Id != 0)
        //    {
        //        ProjectDetail pro = new ProjectDetail()
        //        {
        //            ProjectName = project.ProjectName,
        //            ProjectClassification = project.ProjectClassification,
        //            ProjectDescription = project.ProjectDescription,
        //            ProjectObjectives = project.ProjectObjectives,
        //            ProjectId = project.ProjectId,
        //        };
        //        _dbcontext.project_details.Update(pro);
        //        await _dbcontext.SaveChangesAsync();
        //        return Ok();
        //    }
        //    else
        //    {
        //        ProjectDetail pro = new ProjectDetail()
        //        {
        //            ProjectName = project.ProjectName,
        //            ProjectClassification = project.ProjectClassification,
        //            ProjectDescription = project.ProjectDescription,
        //            ProjectObjectives = project.ProjectObjectives,
        //            ProjectId = project.ProjectId,
        //        };
        //        _dbcontext.project_details.Add(pro);
        //        await _dbcontext.SaveChangesAsync();
        //        return Ok();
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> AddUpdateProjectDuration(ProjectDurationModel project)
        {
            var obj = _dbcontext.project_durations.Where(m => m.Id == project.Id).FirstOrDefault();
            if (project.Id != 0)
            {
                ProjectDuration pro = new ProjectDuration()
                {
                    DurationType = project.DurationType,
                    StartDate = project.StartDate,
                    EndDate = project.StartDate,
                    ProjectId = project.ProjectId,
                };
                _dbcontext.project_durations.Update(pro);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                ProjectDuration pro = new ProjectDuration()
                {
                    DurationType = project.DurationType,
                    StartDate = project.StartDate,
                    EndDate = project.StartDate,
                    ProjectId = project.ProjectId,
                };
                _dbcontext.project_durations.Add(pro);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateProjectScope(ProjectModel project)
        {
            try
            {
                var obj = _dbcontext.project_scopes.Where(m => m.Id == project.Id).FirstOrDefault();
                //var Array = JsonConvert.DeserializeObject(project.Deliverable);
                //var array = project.Deliverable.GetType().ob
                //var array = project.Deliverable;
                //var add = JsonConvert.SerializeObject<ValueKind>(project.Deliverable);
                //ValueKind objArray = (ValueKind) JsonSerializer.Deserialize<ValueKind>(project.Deliverable);
                var split = project.Deliverable.split("object:");
                ValueKind objArray2 = JsonConvert.DeserializeObject<ValueKind>(project.Deliverable);
                if (project.Id != 0)
                {
                    //string jjj = JsonConvert.Parse(project.Deliverable);
                    ProjectScope pro = new ProjectScope()
                    {

                        //Deliverable = project.Deliverable,
                        //Milestone = project.Milestone,
                        //ProjectId = project.ProjectId,
                    };
                    _dbcontext.project_scopes.Update(pro);
                    await _dbcontext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    ProjectScope pro = new ProjectScope()
                    {
                        //Deliverable = project.Deliverable,
                        //Milestone = project.Milestone,
                        //ProjectId = project.ProjectId,
                    };
                    _dbcontext.project_scopes.Add(pro);
                    await _dbcontext.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
        #endregion
    }
}
