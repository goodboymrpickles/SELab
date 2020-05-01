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

        //Add trip
        public void AddClass(string subjectTitle, string description)
        {

            classRepository.Add(new Class()
            {
                Id = Guid.NewGuid(),
                Subject_Title = subjectTitle,
                Description = description,
            });
        }

        ////Remove trip
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
