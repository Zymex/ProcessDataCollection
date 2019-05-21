using KittingApplication.ActiveDirectory;
using Microsoft.EntityFrameworkCore;
using ProcessDataCollection._ApplicationModels.DataModels;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.Audit;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.DataTemplate;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.Process;
using ProcessDataCollection._ApplicationModels.DataModels.AdminModels.ResolutionDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
                
        }
        public ApplicationContext(DbContextOptions options)  : base(options)  {      }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
        
        //Template Table Prefix
        public DbSet<KitTemplate> TPL_KitTemplates { get; set; }
        public DbSet<ProcessTemplate> TPL_ProcessTemplates { get; set; }
        
        // Resolution Table Prefix
        public DbSet<Reason> RES_Reasons { get; set; }
        public DbSet<ReasonCategory> RES_ReasonCategories { get; set; }
        public DbSet<CategoryItems> RES_CategoryItems { get; set; }
        
        //Process Table
        public DbSet<ProcessDefinitions> DEF_ProcessDefinitions { get; set; }

        //Audit Tables
        public DbSet<ApplicationActionLog> AU_APPLICATION_LOG { get; set; }
        public DbSet<UserActionLog> AU_USER_LOG { get; set; }
        public DbSet<KitActionLog> AU_KIT_LOG { get; set; }
        public DbSet<ProcessActionLog> AU_PROCESS_LOG { get; set; }


        //
        // 
        //

        //Regular Application Objects
        public DbSet<Kit> _Kit { get; set; }
        public DbSet<Process> _Processes { get; set; }
        public DbSet<ProcessEntries> _ProcessEntries { get; set; }
        public DbSet<ProcessItems> _ProcessItems { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
