using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.DataAccess
{
    public class TeacherRepository: BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(EDUProjectsDbContext dbContext) : base(dbContext)
        {

        }

        public Teacher GetTeacherByEmail(string teacherEmail)
        {
            return dbContext.Teachers.Where(teacher => teacher.Email == teacherEmail).SingleOrDefault();
        }

        public Teacher GetTeacherById(Guid userId)
        {
            return dbContext.Teachers

                           .Where(teacher => teacher.Id == userId)

                           .SingleOrDefault();
        }

        
    }
}
