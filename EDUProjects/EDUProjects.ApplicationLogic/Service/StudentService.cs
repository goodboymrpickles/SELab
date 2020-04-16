using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Service
{
    public class StudentService
    {
        IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public Student GetStudentById(Guid Id)
        {
            if (Id == null)
            {
                throw new Exception("Null  id");
            }

            return studentRepository.GetStudentById(Id);

        }

        public IEnumerable<Student> GetAll()
        {
            return studentRepository.GetAll();
        }
    }
}
