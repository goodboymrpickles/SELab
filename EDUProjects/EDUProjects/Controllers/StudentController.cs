using EDUProjects.ApplicationLogic.Data;
using EDUProjects.ApplicationLogic.Service;
using EDUProjects.Models.StudentModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUProjects.Controllers
{

    public class StudentController : Controller
    {
        private readonly StudentService studentService;
        private IEnumerable<Student> students;

        public StudentController(StudentService studentService)
        {

            this.studentService = studentService;
        }

        // GET: Student
        public ActionResult Index()
        {
            try
            {
                var classes = studentService.GetAll();

                return View(new GetAllStudentsViewModel { Students = students });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

    }
}
