using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Services
{
    public class ClassService
    {
        IClassRepository classRepository;

        public ClassService(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public Class GetClassByProjectId(Guid projectId)
        {
            if (projectId == null)
            {
                throw new Exception("Null project id");
            }

            return classRepository.GetClassByProjectId(projectId);

        }

        public IEnumerable<Class> GetAll()
        {
            return classRepository.GetAll();
        }
    }
}
