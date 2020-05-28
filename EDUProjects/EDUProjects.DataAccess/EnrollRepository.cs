using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDUProjects.DataAccess
{
    public class EnrollRepository : BaseRepository<Enrollment>, IEnrollRepository
    {
        public EnrollRepository(EDUProjectsDbContext dbContext) : base(dbContext)
        {

        }


        public Enrollment GetEnrollByClassId(Guid classId)
        {
            var oneClass = dbContext.Enrollments.Where(p => p.Classes.Any(project => project.Id == classId)).SingleOrDefault();
            return oneClass;
        }
    }
}
