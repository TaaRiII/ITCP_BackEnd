using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ITCPBackendContext _dbcontext;
        public ProjectController(ITCPBackendContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper= mapper;
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
        public async Task<IActionResult> AddUpdateProjectDuration(ProjectDurationModel project)
        {

            try
            {
                //var token = new JwtSecurityToken(projects.accesstoken);
                //var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
                //Client getClient = _dbcontext.clients.Find(claimsId);
                //var data = _mapper.Map<IList<ProjectDuration>>(projects);
                //_dbcontext.project_durations.UpdateRange(data);
                //await _dbcontext.SaveChangesAsync();
                //var token = new JwtSecurityToken(project.accesstoken);
                //var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
                //Client getClient = _dbcontext.clients.Find(claimsId);
                //var obj = _dbcontext.projects.Where(m => m.Id == project.Id).FirstOrDefault();
                //if (project.Id != 0)
                //{

                //    Project pro = new Project()
                //    {
                //        MDA = project.MDA,
                //        BudgetCode = project.BudgetCode,
                //        //MDASector = project.MDASector,
                //        ModifiedBy = getClient.Username,
                //        ModifiedDate = DateTime.Now,
                //    };
                //    _dbcontext.projects.Add(pro);
                //    await _dbcontext.SaveChangesAsync();
                //    ProjectDetail prodetail = new ProjectDetail()
                //    {
                //        ProjectName = project.ProjectName,
                //        ProjectClassification = project.ProjectClassification,
                //        ProjectDescription = project.ProjectDescription,
                //        ProjectObjectives = project.ProjectObjectives,
                //        ProjectId = pro.Id,
                //    };
                //    _dbcontext.project_details.Update(prodetail);
                //    await _dbcontext.SaveChangesAsync();
                //    return Ok();
                //}
                //else
                //{
                    ProjectDuration pro = new ProjectDuration()
                    {
                        ProjectId = project.ProjectId ?? 0,
                        DurationType = project.DurationType,
                        //MDASector = project.MDASector,
                        FirstStartDate = project.FirstStartDate,
                        FirstEndDate = project.FirstEndDate,
                        SecondEndDate = project.SecondEndDate,
                        SecondStartDate = project.SecondStartDate,
                        ThirdEndDate = project.ThirdEndDate,
                        ThirdStartDate = project.ThirdStartDate,
                    };
                    _dbcontext.project_durations.Add(pro);
                    await _dbcontext.SaveChangesAsync();
                    return Ok();
                //}

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
        public async Task<IActionResult> AddUpdateProjectCost(CostDto project)
        {
            try
            {
                //var token = new JwtSecurityToken(project.accesstoken);
                //var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
                //Client getClient = _dbcontext.clients.Find(claimsId);
                //var data = _mapper.Map<ProjectCost>(project);

                IList<ExtracostDto> extracosts= new List<ExtracostDto>();
                ProjectCost cost = new ProjectCost();
                extracosts.Add(new ExtracostDto { description = project.costDetails.costdescription, amount = project.costDetails.costamount });

                foreach (var item in project.costDetails.extracosts)
                {
                    extracosts.Add(new ExtracostDto { description = item.description, amount = item.amount });
                }
                cost.ProjectId = project.ProjectId;
                cost.CostDetails = JsonConvert.SerializeObject(extracosts);
                _dbcontext.project_costs.Add(cost);
                await _dbcontext.SaveChangesAsync();
                return Ok(Constants.Message.AddMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddProjectSustainability(SustainabilityDto project)
        {
            try
            {
                IList<AddSustainabilityArrayDto> extra = new List<AddSustainabilityArrayDto>();
                ProjectStrategyAndState strategyAndState = new ProjectStrategyAndState();
                extra.Add(new AddSustainabilityArrayDto { CurrentStateArr = project.sustainabilityDetail.CurrentState, DescribeArr = project.sustainabilityDetail.Describe, ProjectTitleArr = project.sustainabilityDetail.ProjectTitle });
                strategyAndState.ProjectId = project.ProjectId;

                foreach (var item in project.sustainabilityDetail.addSustainabilityArray)
                {
                    extra.Add(new AddSustainabilityArrayDto { CurrentStateArr = item.CurrentStateArr, DescribeArr = item.DescribeArr, ProjectTitleArr = item.ProjectTitleArr });
                }
                strategyAndState.Details = JsonConvert.SerializeObject(extra);
                _dbcontext.project_strategy_and_state.Add(strategyAndState);
                await _dbcontext.SaveChangesAsync();
                return Ok(Constants.Message.AddMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ProjectData(int id)
        {
            try
            {
                var JoinProject = (from project in _dbcontext.projects.Where(m => m.Id == id)
                                  from detail in _dbcontext.project_details.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                  from duration in _dbcontext.project_durations.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                  from scope in _dbcontext.project_scopes.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                  from cost in _dbcontext.project_costs.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                  from sustain in _dbcontext.project_strategy_and_state.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                  select new CompeteProjectDto
                                  {
                                      Id = id,
                                      MDA = project.MDA,
                                      BudgetCode = project.BudgetCode,
                                      MDASector = project.MDASector,
                                      ProjectName = detail.ProjectName,
                                      ProjectDescription = detail.ProjectDescription,
                                      ProjectClassification = detail.ProjectClassification,
                                      ProjectObjectives = detail.ProjectObjectives,
                                      DurationType = duration.DurationType,
                                      FirstEndDate = duration.FirstEndDate,
                                      FirstStartDate = duration.FirstStartDate,
                                      SecondStartDate = duration.SecondStartDate,
                                      SecondEndDate = duration.SecondEndDate,
                                      ThirdStartDate = duration.ThirdStartDate,
                                      ThirdEndDate = duration.ThirdEndDate,
                                      SustainabilityName = sustain.SustainabilityName,
                                      Details = sustain.Details,
                                  }).ToList();
                return Ok(JoinProject);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult ProjectListEntryUser()
        {
            try
            {
                var JoinProject = (from project in _dbcontext.projects
                                   from detail in _dbcontext.project_details.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                   select new CompeteProjectDto
                                   {
                                       Id = project.Id,
                                       MDA = project.MDA,
                                       BudgetCode = project.BudgetCode,
                                       MDASector = project.MDASector,
                                       ProjectName = detail.ProjectName,
                                       ProjectDescription = detail.ProjectDescription,
                                       ProjectClassification = detail.ProjectClassification,
                                       ProjectObjectives = detail.ProjectObjectives                                     
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
