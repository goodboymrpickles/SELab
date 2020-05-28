using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDUProjects.DataAccess
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(EDUProjectsDbContext dbContext) : base(dbContext)
        {

        }

        public Project GetProjectById(Guid projectId)
        {
            return dbContext.Projects.Where(project => project.Id == projectId).SingleOrDefault();

        }
    }
}