using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Abstractions
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetStudentById(Guid studentId );
    }
}
