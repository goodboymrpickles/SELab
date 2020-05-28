using CourseManager.ApplicationLogic.Exceptions;
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
        IProjectRepository projectRepository;

        public ClassService(IClassRepository classRepository, IProjectRepository projectRepository )
        {
            this.classRepository = classRepository;
            this.projectRepository = projectRepository;
        }

        public Class GetClassByProjectId(string projectId)
        {
            Guid projectIdGuid = Guid.Empty;
            if (!Guid.TryParse(projectId, out projectIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            if (projectId == null)
            {
                throw new Exception("Null project id");
            }

            var oneClass = classRepository.GetClassByProjectId(projectIdGuid);
            
            if (oneClass == null)
            {
                throw new EntityNotFoundException(projectIdGuid);
            }

            return oneClass;
        }

        public Class GetClassById(string classId)
        {
            Guid classIdGuid = Guid.Empty;
            if (!Guid.TryParse(classId, out classIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            if (classId == null)
            {
                throw new Exception("Null project id");
            }

            var oneClass = classRepository.GetClassById(classIdGuid);

            if (oneClass == null)
            {
                throw new EntityNotFoundException(classIdGuid);
            }
            return oneClass;
        }
        public IEnumerable<Class> GetAll()
        {
            return classRepository.GetAll();
        }

        //Add trip
        public void AddClass(string subjectTitle, string description)
        {

            classRepository.Add(new Class()
            {
                Id = Guid.NewGuid(),
                SubjectTitle = subjectTitle,
                Description = description,
            });
        }

        ////Remove class
        //public void RemoveClass(string classId)
        //{
        //    Guid classIdGuid = Guid.Empty;
        //    if (!Guid.TryParse(classId, out classIdGuid))
        //    {
        //        throw new Exception("Invalid Guid Format");
        //    }
        //    var class = classRepository.GetClassBy(classId);
        //    classRepository.Delete(class);
        //}

        public string GetClassName(Guid id)
        {
            var classObj = classRepository.GetClassById(id);
            return classObj.SubjectTitle;
        }

        public void DeleteClass(Guid classId)
        {
            var oneClass = classRepository.GetClassById(classId);
            classRepository.Delete(oneClass);
        }

    //public void UpdateClass(Guid classId, string subjectTitle, string description)
    //{
    //    //Guid tripIdGuid = Guid.Empty;
    //    //if (!Guid.TryParse(classId, out classIdGuid))
    //    //{
    //    //    throw new Exception("Invalid Guid Format");
    //    //}

    //    var class = tripRepository.GetTripBy(tripId);
    //    class.Subject_title = subjectTitle;
    //    class.Description = description;
    //   
    //    classRepository.Update(trip);
    //}
}
}
