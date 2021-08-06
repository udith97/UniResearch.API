using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniResearch.API.Database;
using UniResearch.API.Entity;

namespace UniResearch.API.Repository
{
    public class ProjectRepository
    {
        private readonly UniResearchContext _dbContext;
        public ProjectRepository(UniResearchContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GetById
        public async Task<Project> GetById(int projectId)
        {
            var project = await _dbContext.Projects.AsNoTracking().FirstOrDefaultAsync(o => o.ProjectId == projectId);
            return project;
        }

        //Update
        public async Task Update(Project project)
        {
            _dbContext.Projects.Update(project);
            await _dbContext.SaveChangesAsync();

        }

        //Insert
        public async Task<Project> Insert(Project project)
        {
            var insertedProjects = _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();
            return insertedProjects.Entity;
        }


        //Delete
        public async Task Delete(int projectId)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(o => o.ProjectId == projectId);
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
        }

        //Search
        public async Task<List<Project>> Search(string searchText)
        {
            var projects = await _dbContext.Projects
                .AsNoTracking()
                .Where(o => EF.Functions.Like(o.ProjectName, $"%{searchText}%")
                || EF.Functions.Like(o.Description, $"%{searchText}%")
                || EF.Functions.Like(o.Budget, $"%{searchText}%"))
                .ToListAsync();

            return projects;
        }

        //GetAll
        public async Task<List<Project>> GetAll()
        {
            var projects = await _dbContext.Projects
                .AsNoTracking()
                .ToListAsync();

            return projects;
        }
    }
}
