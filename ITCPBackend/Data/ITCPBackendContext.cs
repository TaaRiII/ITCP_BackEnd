﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITCPBackend.Model;

namespace ITCPBackend.Data
{
    public class ITCPBackendContext : DbContext
    {
        public ITCPBackendContext (DbContextOptions<ITCPBackendContext> options)
            : base(options)
        {
        }

        public DbSet<ITCPBackend.Model.Users> Users { get; set; } = default!;
        //public DbSet<ITCPBackend.Model.BussinessType> bussinessTypes { get; set; } 
        public DbSet<ITCPBackend.Model.Client> clients { get; set; }
        //public DbSet<ITCPBackend.Model.CompanyContactPerson> companyContactPeople { get; set; }
        //public DbSet<ITCPBackend.Model.Employee> employees { get; set; }
        //public DbSet<ITCPBackend.Model.GenComInfo> genComInfos { get; set; }
        //public DbSet<ITCPBackend.Model.Management> managements { get; set; }
        //public DbSet<ITCPBackend.Model.ServiceCategory> serviceCategories { get; set; }
        //public DbSet<ITCPBackend.Model.Shareholder> shareholders { get; set; }
        //public DbSet<ITCPBackend.Model.Department> departments { get; set; }
        //public DbSet<ITCPBackend.Model.FileUpload> fileUploads { get; set; }
        public DbSet<ITCPBackend.Model.Project> projects { get; set; }
        public DbSet<ITCPBackend.Model.ProjectCost> project_costs { get; set; }
        public DbSet<ITCPBackend.Model.ProjectDetail> project_details { get; set; }
        public DbSet<ITCPBackend.Model.ProjectDuration> project_durations { get; set; }
        public DbSet<ITCPBackend.Model.ProjectScope> project_scopes { get; set; }
        public DbSet<ITCPBackend.Model.CostBreakDown> cost_break_down { get; set; }
        public DbSet<ITCPBackend.Model.ProjectStrategyAndState> project_strategy_and_state { get; set; }
        public DbSet<ITCPBackend.Model.Notification> Notifications { get; set; }

    }
}
