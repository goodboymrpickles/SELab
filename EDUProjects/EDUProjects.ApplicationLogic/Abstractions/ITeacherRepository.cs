using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Abstractions
{
    public interface ITeacherRepository:IRepository<Teacher>
    {
        Teacher GetTeacherById(Guid teacherId);

    }
}
