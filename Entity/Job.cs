using System.ComponentModel.DataAnnotations;

namespace UniResearch.API.Entity
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public JobType JobType { get; set; }
        public float Salary { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}


