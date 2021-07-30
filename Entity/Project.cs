using System.ComponentModel.DataAnnotations;

namespace UniResearch.API.Entity
{
    public class Project {

        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public float Budget { get; set; }
    }
}


// User : userId, name, email, dob, type, hash, salt

// Project : projectId, projectName, description, duration, budget, status

// Job: jobId, companyName, jobType, salary, description, 