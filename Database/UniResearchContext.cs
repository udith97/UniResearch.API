using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniResearch.API.Entity;

namespace UniResearch.API.Database
{

    public class UniResearchContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Project> Projects { get; set; }

        public string DbPath { get; private set; }

        //public UniResearchContext(DbContextOptionsBuilder dbContextOptions)
        //{

        //}

        public UniResearchContext(DbContextOptions<UniResearchContext> options)
            : base(options)
        {
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.

    }
}
