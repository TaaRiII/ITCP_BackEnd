using ITCPBackend.Data;
using ITCPBackend.DTOs;
using ITCPBackend.Helper;
using ITCPBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using NuGet.Protocol;
using System.Collections.Generic;
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

        #region Project
        //[HttpGet]
        //public async Task<ActionResult> GetProjectList(string accesstoken = "")
        //{
        //    var token = new JwtSecurityToken(accesstoken);
        //    var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);

        //}
        #endregion

        #region Application Form
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
        [HttpPost]
        public async Task<IActionResult> AddUpdateProjectDuration(IList<ProjectDurationModel> projects)
        {

            try
            {
                //var token = new JwtSecurityToken(projects.accesstoken);
                //var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
                //Client getClient = _dbcontext.clients.Find(claimsId);
                //var data = _mapper.Map<IList<ProjectDuration>>(projects);
                //_dbcontext.project_durations.UpdateRange(data);
                //await _dbcontext.SaveChangesAsync();
                return Ok(Constants.Message.AddMessage);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateProjectScope(ProjectScopeModel project)
        {
            try
            {
                //var obj = _dbcontext.project_scopes.Where(m => m.Id == project.Id).FirstOrDefault();
                var token = new JwtSecurityToken(project.accesstoken);
                var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
                Client getClient = _dbcontext.clients.Find(claimsId);
                var Deliverable = project.Deliverable;
                var CommaSaperetedDeliverable = string.Join(",", Deliverable);
                var Milestone = project.Milestone;
                var CommaSaperetedMilestone = string.Join(",", Milestone);
                var obj = _dbcontext.projects.Where(m => m.Id == project.Id).FirstOrDefault();
                if (project.Id != 0)
                {
                    //var Array = JsonConvert.DeserializeObject(project.Deliverable);
                    //var array = project.Deliverable.GetType().ob
                    //var array = project.Deliverable;
                    //var add = JsonConvert.SerializeObject<ValueKind>(project.Deliverable);
                    //ValueKind objArray = (ValueKind) JsonSerializer.Deserialize<ValueKind>(project.Deliverable);
                    //var split = project.Deliverable.ToJson();
                //object objArray2 = JsonConvert.DeserializeObject<object>(project.Deliverable);
                    //string jjj = JsonConvert.Parse(project.Deliverable);
                    ProjectScope pro = new ProjectScope()
                    {
                        Deliverable = CommaSaperetedDeliverable,
                        Milestone = CommaSaperetedMilestone,
                        ProjectId = project.ProjectId ?? 0,
                    };
                    _dbcontext.project_scopes.Update(pro);
                    await _dbcontext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    ProjectScope pro = new ProjectScope()
                    {
                        Deliverable = CommaSaperetedDeliverable,
                        Milestone = CommaSaperetedMilestone,
                        ProjectId = project.ProjectId ?? 0,
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
        [HttpPost]
        public async Task<IActionResult> AddUpdateProjectCost(ProjectCostDto project)
        {
            try
            {
                var token = new JwtSecurityToken(project.accesstoken);
                var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
                Client getClient = _dbcontext.clients.Find(claimsId);
                //var data = _mapper.Map<ProjectCost>(project);
                //_dbcontext.project_costs.UpdateRange(data);
                //await _dbcontext.SaveChangesAsync();
                return Ok(Constants.Message.AddMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
