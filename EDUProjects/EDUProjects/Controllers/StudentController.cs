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
        private readonly RegisterService registerService;
       

        public StudentController(StudentService studentService, RegisterService registerService)
        {

            this.studentService = studentService;
            this.registerService = registerService;
        }

        // GET: Student
        public ActionResult Index()
        {
            try
            {
                var students = studentService.GetAll();

                return View(new GetAllStudentsViewModel { Students = students });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent([FromForm] AddStudentViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            registerService.AddStudent(model.FullName, model.University, model.Section, model.Email,
                model.BirthDate, model.Phone_Number, model.Address); 

            return Redirect(Url.Action("Index", "StudentRegister"));
        }

    }
}
