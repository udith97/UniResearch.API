using System;

namespace UniResearch.API.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
        public UserType UserType { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }

    }
}


// User : userId, name, email, dob, type, hash, salt

// Project : projectId, projectName, description, duration, budget, status

// Job: jobId, companyName, jobType, salary, description, 