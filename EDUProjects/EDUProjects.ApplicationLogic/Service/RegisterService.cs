using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Service
{
    public class RegisterService
    {
        IStudentRepository studentRepository;
        ITeacherRepository teacherRepository;

        public RegisterService(IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
        }

        public void AddTeacher(string fullname, string department, string email, DateTime birthdate, string address)
        {
            teacherRepository.Add(new Teacher()
            {
                Id = Guid.NewGuid(),
                Full_Name = fullname,
                Department = department,
                Email = email,
                Birth_Date = birthdate,
                Address = address,
            });
        }

        public void AddStudent(string name, string university, string section, string email, 
            DateTime birthdate, string phoneNr, string address)
        {
            studentRepository.Add(new Student()
            {
                Id = Guid.NewGuid(),
                Name = name,
                University = university, 
                Section = section,
                Email = email, 
                Birth_Date = birthdate, 
                Phone_Number = phoneNr, 
                Address = address,
            });
        }
    }
}
