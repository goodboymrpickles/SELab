using CourseManager.ApplicationLogic.Exceptions;
using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EDUProjects.ApplicationLogic.Service
{
   public class TeacherService
    {
        ITeacherRepository teacherRepository;
        IGradingRepository gradingRepository;
        IClassRepository classRepository;
        IStudentRepository studentRepository;
        IEnrollRepository enrollRepository;

        public TeacherService(ITeacherRepository teacherRepository, IGradingRepository gradingRepository, IClassRepository classRepository, IStudentRepository studentRepository, IEnrollRepository enrollRepository) {  
            this.gradingRepository = gradingRepository;
            this.teacherRepository = teacherRepository;
            this.studentRepository = studentRepository;
            this.classRepository = classRepository;
            this.enrollRepository = enrollRepository;
        }

        public Teacher GetTeacherById(Guid teacherId)
        {

           if(teacherId == null)
            {
                throw new Exception("Null project id");
            }

            return teacherRepository.GetTeacherById(teacherId);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return teacherRepository.GetAll();
        }
        public Teacher GetTeacherByEmail(string teacherEmail)
        {
            return teacherRepository.GetTeacherByEmail(teacherEmail);
        }

        public void AddComment(string comment, int grade, string teacherEmail)
        {
            Teacher teacher = teacherRepository.GetTeacherByEmail(teacherEmail);

            Boolean is_Passed; 
            if(grade >= 5)
            {
                is_Passed = true;
            }else
            {
                is_Passed = false;
            }

            gradingRepository.Add(new Grading()
            {
                Id = Guid.NewGuid(),
                Teacher = teacher,
                Feedback = comment,
                Grade = grade,
                Is_Passed = is_Passed
            }) ;
     
        }

        public void AddStudentsToClass(Student nameStudent, Class nameClass)
        {

            ICollection<Student> students = new Collection<Student>();
            students.Add(nameStudent);

            ICollection<Class> classes = new Collection<Class>();
            classes.Add(nameClass);

            enrollRepository.Add(new Enrollment()
            {
                Id = Guid.NewGuid(),
                Students = students,
                Classes = classes,



            }) ;
        }
    }
}
