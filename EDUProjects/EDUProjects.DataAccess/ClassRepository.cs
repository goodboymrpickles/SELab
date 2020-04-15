using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDUProjects.DataAccess
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(EDUProjectsDbContext dbContext) : base(dbContext)
        {

        }
        public Class GetClassByProjectId(Guid projectId)
        {
            var oneClass = dbContext.Classes.Where(p => p.Projects.Any(project => project.Id == projectId)).SingleOrDefault();
            return oneClass;
        }
    }
}
