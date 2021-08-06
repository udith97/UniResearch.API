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
    public class ProjectService
    {
        private readonly ProjectRepository _projectRepository;
        public ProjectService(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ActionResult<Project>> GetByIdAsync(int projectId)
        {
            var project = await _projectRepository.GetById(projectId);
            if (project != null)
            {
                return new ActionResult<Project>(project);
            }
            return new NoContentResult();

        }

        public async Task<ActionResult<List<ProjectDTO>>> GetProjects(string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                var filteredProjects = await _projectRepository.Search(search);
                var filteredProjectsDTOs = filteredProjects.Select(o => new ProjectDTO { ProjectId = o.ProjectId, ProjectName = o.ProjectName, Description = o.Description, Duration = o.Duration, Budget = o.Budget }).ToList();
                return new ActionResult<List<ProjectDTO>>(filteredProjectsDTOs);


            }
            var projects = await _projectRepository.GetAll();
            var projectDTOs = projects.Select(o => new ProjectDTO { ProjectId = o.ProjectId, ProjectName = o.ProjectName, Description = o.Description, Duration = o.Duration, Budget = o.Budget }).ToList();
            return new ActionResult<List<ProjectDTO>>(projectDTOs);

        }
    }
}
