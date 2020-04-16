using System;
using System.Collections.Generic;
using System.Text;
using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EDUProjects.DataAccess

{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(EDUProjectsDbContext dbContext) : base(dbContext)
        {

        }
        public Student GetStudentById(Guid Id)
        {
            var oneStudent = dbContext.Students.Where((student => student.Id == Id)).SingleOrDefault();
            return oneStudent;
        }
    }
}