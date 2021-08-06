using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniResearch.API.DTOs
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public float Budget { get; set; }
    }
}
