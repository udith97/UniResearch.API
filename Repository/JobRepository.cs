using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniResearch.API.Database;
using UniResearch.API.Entity;

namespace UniResearch.API.Repository
{
    public class JobRepository
    {
       
        private readonly UniResearchContext _dbContext;
        public JobRepository(UniResearchContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GetById
        public async Task<Job> GetById(int jobId) 
        {
            var job = await _dbContext.Jobs.AsNoTracking().FirstOrDefaultAsync(o => o.JobId == jobId);
            return job;
        }

        //Update
        public async Task Update(Job job) 
        {
            _dbContext.Jobs.Update(job);
            await _dbContext.SaveChangesAsync();

        }

        //Insert
        public async Task<Job> Insert(Job job)
        {
            var  insertedJob =  _dbContext.Jobs.Add(job);
            await _dbContext.SaveChangesAsync();
            return insertedJob.Entity;
        }

        //Delete
        public async Task Delete(int jobId)
        {
            var job = await _dbContext.Jobs.FirstOrDefaultAsync(o => o.JobId == jobId);
            _dbContext.Jobs.Remove(job);
            await _dbContext.SaveChangesAsync();
        }

        //Search
        public async Task<List<Job>> Search(string searchText)
        {
            var jobs = await _dbContext.Jobs
                .AsNoTracking()
                .Where(o => EF.Functions.Like(o.CompanyName, $"%{searchText}%") 
                || EF.Functions.Like(o.Description, $"%{searchText}%") 
                || EF.Functions.Like(o.Location, $"%{searchText}%"))
                .ToListAsync();

            return jobs;
        }

        //GetAll
        public async Task<List<Job>> GetAll()
        {
            var jobs = await _dbContext.Jobs
                .AsNoTracking()
                .ToListAsync();

            return jobs;
        }

    }



    
}
