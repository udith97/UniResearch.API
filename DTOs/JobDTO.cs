using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniResearch.API.Entity;

namespace UniResearch.API.DTOs
{
    public class JobDTO
    {
        public int JobId { get; set; }
        public JobType JobType { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }


    }
}
