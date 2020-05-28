using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Abstractions
{
    public interface IClassRepository : IRepository<Class>
    {
        Class GetClassByProjectId(Guid projectId);

        Class GetClassById(Guid classId);

        Class GetClassByName(string name);

    }
}
