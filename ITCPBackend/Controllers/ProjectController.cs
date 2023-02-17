using AutoMapper;
using ITCPBackend.Data;
using ITCPBackend.DTOs;
using ITCPBackend.Helper;
using ITCPBackend.Migrations;
using ITCPBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Common;
using NuGet.Protocol;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
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
            _mapper = mapper;
        }

        #region Application Form Submit
        [HttpPost]
        public async Task<IActionResult> AddUpdateProject(ProjectModel project)
        {
            string accesstoken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var token = new JwtSecurityToken(accesstoken);
            var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
            Client getClient = _dbcontext.clients.Find(claimsId);
            var obj = _dbcontext.projects.Where(m => m.Id == project.Id).FirstOrDefault();
            if (project.Id != 0)
            {
                obj.MDA = project.MDA;
                obj.BudgetCode = project.BudgetCode;
                obj.MDASector = (int)project.MDASector;
                obj.ModifiedDate = DateTime.Now;
                obj.ModifiedBy = getClient.Username;
                obj.ClientId = getClient.Id;
                _dbcontext.projects.Update(obj);
                await _dbcontext.SaveChangesAsync();
                var projectDetailModel = _dbcontext.project_details.Where(m => m.ProjectId == project.Id).FirstOrDefault();
                projectDetailModel.ProjectName = project.ProjectName;
                projectDetailModel.ProjectClassification = project.ProjectClassification;
                projectDetailModel.ProjectDescription = project.ProjectDescription;
                projectDetailModel.ProjectObjectives = project.ProjectObjectives;
                _dbcontext.project_details.Update(projectDetailModel);
                await _dbcontext.SaveChangesAsync();
                return Ok(obj.Id);
            }
            else
            {
                Project pro = new Project()
                {
                    MDA = project.MDA,
                    BudgetCode = project.BudgetCode,
                    MDASector = (int)project.MDASector,
                    CreatedDate = DateTime.Now,
                    CreatedBy = getClient.Username,
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
                var DurationProject = _dbcontext.project_durations.Where(m => m.Id == project.Id).FirstOrDefault();
                if (DurationProject == null)
                {
                    ProjectDuration pro = new ProjectDuration()
                    {
                        ProjectId = project.ProjectId ?? 0,
                        DurationType = project.DurationType,
                        FirstStartDate = project.FirstStartDate,
                        FirstEndDate = project.FirstEndDate,
                        SecondEndDate = project.SecondEndDate,
                        SecondStartDate = project.SecondStartDate,
                        ThirdEndDate = project.ThirdEndDate,
                        ThirdStartDate = project.ThirdStartDate,
                    };
                    _dbcontext.project_durations.Add(pro);
                    await _dbcontext.SaveChangesAsync();
                }
                else
                {
                    DurationProject.ProjectId = project.ProjectId ?? 0;
                    DurationProject.DurationType = project.DurationType;
                    DurationProject.FirstStartDate = project.FirstStartDate;
                    DurationProject.FirstEndDate = project.FirstEndDate;
                    DurationProject.SecondEndDate = project.SecondEndDate;
                    DurationProject.SecondStartDate = project.SecondStartDate;
                    DurationProject.ThirdEndDate = project.ThirdEndDate;
                    DurationProject.ThirdStartDate = project.ThirdStartDate;
                    _dbcontext.project_durations.Update(DurationProject);
                    await _dbcontext.SaveChangesAsync();
                }
                return Ok();
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
                var ScopeProject = _dbcontext.project_scopes.Where(m => m.Id == project.Id).FirstOrDefault();
                if (ScopeProject == null)
                {
                    ProjectScope pro = new ProjectScope()
                    {
                        Details = JsonConvert.SerializeObject(project.ScopeDetail.detail),
                        ProjectId = project.ProjectId
                    };
                    _dbcontext.project_scopes.Add(pro);
                }
                else
                {
                    ScopeProject.Details = JsonConvert.SerializeObject(project.ScopeDetail.detail);
                    ScopeProject.ProjectId = project.ProjectId;
                    _dbcontext.project_scopes.Update(ScopeProject);
                }
                await _dbcontext.SaveChangesAsync();
                return Ok();
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

                //IList<ExtracostDto> extracosts = new List<ExtracostDto>();
                var CostModel = _dbcontext.project_costs.Where(m => m.Id == project.Id).FirstOrDefault();
                if(CostModel == null)
                {
                    ProjectCost cost = new ProjectCost();
                    //extracosts.Add(new ExtracostDto { description = project.costDetails.costdescription, amount = project.costDetails.costamount });
                    // var project = _dbcontext.projects.Where(m => m.Id == project.Id).FirstOrDefault();
                    //foreach (var item in project.costDetails.extracosts)
                    //{
                    //    extracosts.Add(new ExtracostDto { description = item.description, amount = item.amount });
                    //}
                    cost.CostDetails = JsonConvert.SerializeObject(project.costDetails.extracosts);
                    _dbcontext.project_costs.Add(cost);
                }
                else
                {
                    //extracosts.Add(new ExtracostDto { description = project.costDetails.costdescription, amount = project.costDetails.costamount });
                    // var project = _dbcontext.projects.Where(m => m.Id == project.Id).FirstOrDefault();
                    //foreach (var item in project.costDetails.extracosts)
                    //{
                    //    extracosts.Add(new ExtracostDto { description = item.description, amount = item.amount });
                    //}
                    CostModel.CostDetails = JsonConvert.SerializeObject(project.costDetails.extracosts);
                    _dbcontext.project_costs.Update(CostModel);
                }
                
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
                //var SustainProject = _dbcontext.project_strategy_and_state.Where(m => m.Id == project.Id).FirstOrDefault();
              //  IList<AddSustainabilityArrayDto> extra = new List<AddSustainabilityArrayDto>();
              var SustainModel = _dbcontext.project_strategy_and_state.Where(m => m.Id != project.Id).FirstOrDefault();
                if(SustainModel == null)
                {
                    ProjectStrategyAndState strategyAndState = new ProjectStrategyAndState();
                    strategyAndState.SustainabilityName = project.strategy;
                    strategyAndState.JobType = (int)project.JobType;
                    //foreach (var item in project.sustainabilityDetail.addSustainabilityArray)
                    //{
                    //    extra.Add(new AddSustainabilityArrayDto { CurrentStateArr = item.CurrentStateArr, DescribeArr = item.DescribeArr, ProjectTitleArr = item.ProjectTitleArr });
                    //}
                    strategyAndState.Details = JsonConvert.SerializeObject(project.sustainabilityDetail.addSustainabilityArray);
                    _dbcontext.project_strategy_and_state.Add(strategyAndState);
                }
                else
                {
                    SustainModel.SustainabilityName = project.strategy;
                    SustainModel.JobType = (int)project.JobType;
                    //foreach (var item in project.sustainabilityDetail.addSustainabilityArray)
                    //{
                    //    extra.Add(new AddSustainabilityArrayDto { CurrentStateArr = item.CurrentStateArr, DescribeArr = item.DescribeArr, ProjectTitleArr = item.ProjectTitleArr });
                    //}
                    SustainModel.Details = JsonConvert.SerializeObject(project.sustainabilityDetail.addSustainabilityArray);
                    _dbcontext.project_strategy_and_state.Update(SustainModel);
                }
                await _dbcontext.SaveChangesAsync();
                return Ok(Constants.Message.AddMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdateProjectPolicy(ProjectPolicyDto project)
        {
            try
            {
                string accesstoken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var token = new JwtSecurityToken(accesstoken);
                var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
                var res = _dbcontext.projects.Where(m => m.Id == project.ProjectId).FirstOrDefault();
                res.Policies = project.Policies;
                if (res.Status == (int)Constants.ProjectStatus.Draft || res.Status == (int)Constants.ProjectStatus.MDAReject)
                {
                    var MDAModel = _dbcontext.clients.Where(m => m.Id == claimsId).FirstOrDefault();
                    Notification notification = new Notification();
                    notification.CreatedDate = DateTime.Now;
                    notification.Status = 0;
                    notification.ToID = (int)MDAModel.MDAId;
                    notification.FromID = claimsId;
                    notification.ProjectId = project.ProjectId;
                    if (res.Status == (int)Constants.ProjectStatus.Draft)
                    {
                        notification.NotificationName = "New Application";
                        notification.Msg = "Added By the" + MDAModel.Name;
                    }
                    else
                    {
                        notification.NotificationName = "Resubmitted Application";
                        notification.Msg = "Application are Received from Rejected Applications By the" + MDAModel.Name;
                    }
                    _dbcontext.Notifications.Add(notification);
                    res.Status = (int)Constants.ProjectStatus.Submit;
                    
                }

                _dbcontext.projects.Update(res);
                await _dbcontext.SaveChangesAsync();
                return Ok(Constants.Message.AddMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region Application Form Get
        [HttpGet]
        public IActionResult ProjectData(int id)
        {
            try
            {
                CompeteProjectDto JoinProject = (from project in _dbcontext.projects.Where(m => m.Id == id)
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
                                                     RejectNotes = project.RejectNotes,
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
                                                     SustainDetails = sustain.Details,
                                                     costId = cost.Id,
                                                     durationId = duration.Id,
                                                     scopeId = scope.Id,
                                                     sutainablityId = sustain.Id,
                                                     costDetail = cost.CostDetails,
                                                     jobType = sustain.JobType,
                                                     ScopeDetails = scope.Details,
                                                     ProjectStatus = project.Status,
                                                     ProjectId = project.Id,
                                                     policies = project.Policies,
                                                 }).FirstOrDefault();
                return Ok(JoinProject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ProjectList(int status)
        {
            try
            {

                if (status == -1)
                {
                    var AllJoinProject = (from project in _dbcontext.projects
                                          from detail in _dbcontext.project_details.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                          select new CompeteProjectDto
                                          {
                                              Id = project.Id,
                                              MDA = project.MDA,
                                              BudgetCode = project.BudgetCode,
                                              MDASector = project.MDASector,
                                              ProjectName = detail.ProjectName,
                                              ProjectStatus = project.Status,
                                              ProjectDescription = detail.ProjectDescription,
                                              ProjectClassification = detail.ProjectClassification,
                                              ProjectObjectives = detail.ProjectObjectives,
                                              ProjectCreated = project.CreatedDate,
                                              projectLevel = project.Status == (int)Constants.ProjectStatus.MDApprove ? "Level 1" :
                                                                             project.Status == (int)Constants.ProjectStatus.SectApprove ? "Level 2" :
                                                                             project.Status == (int)Constants.ProjectStatus.Comeetee ? "Level 3" : ""
                                          }).ToList();
                    return Ok(AllJoinProject);

                }

                var JoinProject = (from project in _dbcontext.projects.Where(m => m.Status == status)
                                   from detail in _dbcontext.project_details.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                   select new CompeteProjectDto
                                   {
                                       Id = project.Id,
                                       MDA = project.MDA,
                                       BudgetCode = project.BudgetCode,
                                       MDASector = project.MDASector,
                                       ProjectName = detail.ProjectName,
                                       RejectNotes = project.RejectNotes,
                                       ProjectDescription = detail.ProjectDescription,
                                       ProjectStatus = project.Status,
                                       ProjectClassification = detail.ProjectClassification,
                                       ProjectObjectives = detail.ProjectObjectives,
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
        [HttpGet]
        public IActionResult FilteredProjectList(int status, DateTime Fromdate, DateTime Todate, int entryUserId)
        {
            try 
            {

                if (status == -1)
                {
                    var AllJoinProject = (from project in _dbcontext.projects.Where(m => m.CreatedDate.Date >= Fromdate && m.CreatedDate.Date <= Todate && entryUserId != 0 ? m.ClientId == entryUserId : true)
                                          from detail in _dbcontext.project_details.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                          select new CompeteProjectDto
                                          {
                                              Id = project.Id,
                                              MDA = project.MDA,
                                              BudgetCode = project.BudgetCode,
                                              MDASector = project.MDASector,
                                              ProjectName = detail.ProjectName,
                                              ProjectStatus = project.Status,
                                              ProjectDescription = detail.ProjectDescription,
                                              ProjectClassification = detail.ProjectClassification,
                                              ProjectObjectives = detail.ProjectObjectives,
                                              ProjectCreated = project.CreatedDate,
                                              projectLevel = project.Status == (int)Constants.ProjectStatus.MDApprove ? "Level 1" :
                                                                             project.Status == (int)Constants.ProjectStatus.SectApprove ? "Level 2" :
                                                                             project.Status == (int)Constants.ProjectStatus.Comeetee ? "Level 3" : ""
                                          }).ToList();
                    return Ok(AllJoinProject);

                }

                var JoinProject = (from project in _dbcontext.projects.Where(m => m.Status == status && m.CreatedDate.Date >= Fromdate && m.CreatedDate.Date <= Todate)
                                   from detail in _dbcontext.project_details.Where(m => m.ProjectId == project.Id).DefaultIfEmpty()
                                   select new CompeteProjectDto
                                   {
                                       Id = project.Id,
                                       MDA = project.MDA,
                                       BudgetCode = project.BudgetCode,
                                       MDASector = project.MDASector,
                                       ProjectName = detail.ProjectName,
                                       RejectNotes = project.RejectNotes,
                                       ProjectDescription = detail.ProjectDescription,
                                       ProjectStatus = project.Status,
                                       ProjectClassification = detail.ProjectClassification,
                                       ProjectObjectives = detail.ProjectObjectives,
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
        [HttpGet]
        public IActionResult ProjectProgressList(int status)
        {
            try
            {
                //if(Fromdate != null && Todate != null)
                //{
                //    FromDate = DateTime.Parse(Fromdate);
                //    ToDate = DateTime.Parse(Todate);
                //}


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
        public IActionResult ProjectProgressListMda(int status)
        {
            try
            {
                //if(Fromdate != null && Todate != null)
                //{
                //    FromDate = DateTime.Parse(Fromdate);
                //    ToDate = DateTime.Parse(Todate);
                //}


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
                return Ok(JoinProject.Where(m => m.ProjectStatus != 3).ToList());
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

        #region Application status Chnage
        [HttpPost]
        public async Task<IActionResult> StatusUpdateAsync(ProjectStatusUpdateDto status)
        {
            try
            {
                string accesstoken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var token = new JwtSecurityToken(accesstoken);
                var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
                var res = _dbcontext.projects.Where(m => m.Id == status.ProjectId).FirstOrDefault();
                res.Status = status.NewStatus;
                res.RejectNotes = status.Note == "nc" ? res.RejectNotes : status.Note;
                _dbcontext.projects.Update(res);
                var EntryModel = _dbcontext.clients.Where(m => m.Id == claimsId).FirstOrDefault();
                Notification notification = new Notification();
                notification.CreatedDate = DateTime.Now;
                notification.Status = 0;
                notification.ToID = res.ClientId;
                notification.FromID = claimsId;
                notification.ProjectId = status.ProjectId;
                notification.NotificationName = "Rejected Application";
                notification.Msg = "Application are Rejected By the" + EntryModel.Name;
                _dbcontext.Notifications.Add(notification);
                await _dbcontext.SaveChangesAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion

        #region Dasboard Counts
        [HttpGet]
        public async Task<IActionResult> CountsDashboard()
        {
            try
            {
                var all = _dbcontext.projects.Count();
                var submit = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.Submit).Count();
                var draft = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.Draft).Count();
                var sectRejected = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.SectReject).Count();
                var mdaRejected = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.MDAReject).Count();
                var mdaApprove = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.MDApprove).Count();
                var sectApprove = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.SectApprove).Count();
                var commitee = _dbcontext.projects.Where(m => m.Status == (int)Constants.ProjectStatus.Comeetee).Count();
                var Allcount = new
                {
                    all = all,
                    submit = submit,
                    draft = draft,
                    sectRejected = sectRejected,
                    mdaRejected = mdaRejected,
                    mdaApprove = mdaApprove,
                    sectApprove = sectApprove,
                    commitee = commitee,
                };
                return Ok(Allcount);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Notification
        [HttpPost]
        public async Task<IActionResult> AddNotification(NotificationDto input) 
        {
            try
            {
                var data = _mapper.Map<Notification>(input);
                _dbcontext.Notifications.Add(data);
                _dbcontext.SaveChanges();
                return Ok("Data Saved");
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
        #endregion
        #region Get MDA LIst
        [HttpGet]
        public async Task<IActionResult> EntryUsersList()
        {
            var EntryList = _dbcontext.clients.Where(m => m.Role == Constants.ClientRoleInt.Entry).ToList();
            return Ok(EntryList);
        }
        [HttpGet]
        public async Task<IActionResult> GetNotification()
        {
            try
            {
                string accesstoken = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var token = new JwtSecurityToken(accesstoken);
                var claimsId = int.Parse(token.Claims.First(claim => claim.Type == "id").Value);
                var data=_dbcontext.Notifications.Where(m => m.ToID == claimsId && m.Status == 0).ToList();
                IList<NotificationModelForResponce> NotificationObjList = new List<NotificationModelForResponce>();
                foreach (var item in data)
                {
                    var SenderName = _dbcontext.clients.Where(m => m.Id == item.FromID).Select(m => m.Name).FirstOrDefault();
                    var ProjectName = _dbcontext.project_details.Where(m => m.ProjectId == item.ProjectId).Select(m => m.ProjectName).FirstOrDefault();
                    NotificationModelForResponce NotificationObj = new NotificationModelForResponce
                    {
                        ProjectId = item.ProjectId,
                        SenderName = SenderName,
                        NotificationTime = (DateTime.Now - item.CreatedDate).Minutes,
                        ToID = item.ToID,
                        FromID = item.FromID,
                        NotificationName = item.NotificationName,
                        Id = item.Id,
                        Msg = item.Msg,
                        ProjectName = ProjectName,
                    };
                    NotificationObjList.Add(NotificationObj);
                }

                return Ok(NotificationObjList);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
        [HttpPost]
        public IActionResult ChangeNotificationStatus(int Id)
        {
            var Notification = _dbcontext.Notifications.Where(m => m.Id == Id).FirstOrDefault();
            Notification.Status = 1;
            _dbcontext.Notifications.Update(Notification);
            _dbcontext.SaveChanges();
            return Ok();
        }
        #endregion

    }
}
