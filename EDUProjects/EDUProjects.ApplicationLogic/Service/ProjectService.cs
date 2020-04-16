using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Service
{
    public class ProjectService
    {
        IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public Project GetProjectByProjectId(Guid projectId)
        {
            if (projectId == null)
            {
                throw new Exception("Null project id");
            }

            return projectRepository.GetProjectById(projectId);

        }

        public IEnumerable<Project> GetAll()
        {
            return projectRepository.GetAll();
        }
    }
}
