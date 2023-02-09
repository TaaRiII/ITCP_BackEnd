﻿using AutoMapper;
using ITCPBackend.Data;
using ITCPBackend.DTOs;
using ITCPBackend.Helper;
using ITCPBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        #region Application Form Submit
        [HttpPost]
        public async Task<IActionResult> AddUpdateProject(ProjectModel project)
        {
            var obj = _dbcontext.projects.Where(m => m.Id == project.Id).FirstOrDefault();
            if (project.Id != 0)
            {

                Project pro = new Project()
                {
                    MDA = project.MDA,
                    BudgetCode = project.BudgetCode,
                    MDASector = (int)project.MDASector,
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
                    MDASector = (int)project.MDASector,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "System",
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
                    _dbcontext.project_durations.Update(pro);
                    await _dbcontext.SaveChangesAsync();
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
                    ProjectScope pro = new ProjectScope()
                    {
                        Id=project.Id,
                        Details =JsonConvert.SerializeObject(project.ScopeDetail.detail),
                        ProjectId = project.ProjectId
                    };
                //_dbcontext.ChangeTracker.Clear();
                _dbcontext.project_scopes.Update(pro);
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
                strategyAndState.SustainabilityName = project.strategy;

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

        [HttpPost]
        public async Task<IActionResult> AddUpdateProjectPolicy(ProjectPolicyDto project)
        {
            try
            {
                var res= _dbcontext.projects.Where(m => m.Id == project.ProjectId).FirstOrDefault();
                res.Policies = project.Policies;
                if (res.Status == (int)Constants.ProjectStatus.Draft)
                {
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
                                                     RejectNotes=project.RejectNotes,
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
                                                     costId = cost.Id,
                                                     durationId = duration.Id,
                                                     scopeId = scope.Id,
                                                     sutainablityId = sustain.Id,
                                                     costDetail = cost.CostDetails,
                                                     jobType = sustain.Details,
                                                     ScopeDetails = scope.Details,
                                                     ProjectStatus=project.Status
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
                                       ProjectCreated=project.CreatedDate,
                                       projectLevel= project.Status==(int)Constants.ProjectStatus.MDApprove? "Level 1":
                                                                      project.Status == (int)Constants.ProjectStatus.SectApprove? "Level 2" : 
                                                                      project.Status == (int)Constants.ProjectStatus.Comeetee ? "Level 3": ""
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
                                       ProjectStatus =project.Status,
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
                var res = _dbcontext.projects.Where(m => m.Id == status.ProjectId).FirstOrDefault();
                res.Status = status.NewStatus;
                res.RejectNotes = status.Note=="nc"? res.RejectNotes:status.Note;
                _dbcontext.projects.Update(res);
                await _dbcontext.SaveChangesAsync();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        #endregion

    }
}
