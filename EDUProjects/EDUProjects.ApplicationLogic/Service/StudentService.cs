using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EDUProjects.ApplicationLogic.Service
{
    public class StudentService
    {
        IStudentRepository studentRepository;
        IClassRepository classRepository;
        IEnrollRepository enrollRepository;
        IGradingRepository gradingRepository;
        ITeacherRepository teacherRepository;

        public StudentService(IStudentRepository studentRepository, IEnrollRepository enrollRepository, IClassRepository classRepository, IGradingRepository gradingRepository, ITeacherRepository teacherRepository)
        {
            this.studentRepository = studentRepository;
            this.enrollRepository = enrollRepository;
            this.classRepository = classRepository;
            this.gradingRepository = gradingRepository;
            this.teacherRepository = teacherRepository;
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
        
        public void AddStudentToClass(string className, string studentName)
        {
            Student student = studentRepository.GetStudentByName(studentName);

            Class classes = classRepository.GetClassByName(className);

            ICollection<Student> students = new Collection<Student>();
            students.Add(student);

            ICollection<Class> classa = new Collection<Class>();
            classa.Add(classes);

            enrollRepository.Add(new Enrollment()
            {
                Id = Guid.NewGuid(),
                Students = students,
                Classes = classa,

            });

        }

       public Student GetStudentByEmail(string studentEmail)
        {
            return studentRepository.GetStudentByEmail(studentEmail);
        }


        public void AddCommentStudent(string comment, string studentEmail)
        {
            //Student student = studentRepository.GetStudentByEmail(studentEmail);
            Teacher student = teacherRepository.GetTeacherByEmail(studentEmail);

            //student = teacher;

            gradingRepository.Add(new Grading()
            {
                Id = Guid.NewGuid(),
                Teacher = student,
                Feedback = comment,
            });

        }

        public void AddStudent(string name)
        {

            studentRepository.Add(new Student()
            {
                Id = Guid.NewGuid(),
                Name = name,
                
            });
        }

    }
}
