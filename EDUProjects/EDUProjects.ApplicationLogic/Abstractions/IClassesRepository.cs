using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Abstractions
{
    public interface IClassesRepository : IRepository<Classes>
    {
        Classes GetTripBy(Guid classId);

        IEnumerable<Classes> GetClasses();
    }
}
