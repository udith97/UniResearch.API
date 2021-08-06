using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniResearch.API.DTOs;
using UniResearch.API.Entity;
using UniResearch.API.Repository;

namespace UniResearch.API.ControllerServices
{
    public class JobService
    {
        private readonly JobRepository _jobRepository;
        public JobService(JobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        //public async Task<Job> GetById(int jobId)
        //{
        //    var job = await _dbContext.Jobs.AsNoTracking().FirstOrDefaultAsync(o => o.JobId == jobId);
        //    return job;
        //}
        public async Task<ActionResult<Job>> GetByIdAsync(int jobId)
        {
            var job = await _jobRepository.GetById(jobId);
            if (job != null) 
            {
                return new ActionResult<Job>(job);
            }
            return new NoContentResult();

        }

        public async Task<ActionResult<List<JobDTO>>> GetJobs(string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                var filteredJobs = await _jobRepository.Search(search);
                var filteredJobsDTOs = filteredJobs.Select(o => new JobDTO {JobId = o.JobId, CompanyName = o.CompanyName, JobType = o.JobType, Location = o.Location }).ToList();
                return new ActionResult<List<JobDTO>>(filteredJobsDTOs);


            }
            var jobs = await _jobRepository.GetAll();
            var jobsDTOs = jobs.Select(o => new JobDTO { JobId = o.JobId, CompanyName = o.CompanyName, JobType = o.JobType, Location = o.Location }).ToList();
            return new ActionResult<List<JobDTO>>(jobsDTOs);

        }


    }
}
