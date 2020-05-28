using EDUProjects.ApplicationLogic.Data;
using EDUProjects.ApplicationLogic.Service;
using EDUProjects.ApplicationLogic.Services;
using EDUProjects.Models.ClassModel;
using EDUProjects.Models.StudentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
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
        private readonly ClassService classService;
       

        public StudentController(StudentService studentService, RegisterService registerService, ClassService classService)
        {

            this.studentService = studentService;
            this.registerService = registerService;
            this.classService = classService;
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

        public ActionResult AddStudentsToClass()
        {
            return View();
        }

        [HttpGet]
        
        public IActionResult EnrollToClass()
        {
            return View();
        }
      
        [HttpPost]
        public IActionResult EnrollToClass([FromForm] EnrollViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            Boolean studentConfirm = false;
            Boolean classesConfirm = false;

            var students = studentService.GetAll();
            var classes = classService.GetAll();

            foreach(var item in students)
            {
                if(item.Name == model.studentName)
                {
                    studentConfirm = true;
                }
            }

            foreach(var item in classes)
            {
                if(item.Subject_Title == model.className)
                {
                    classesConfirm = true;
                }
            }
            if (classesConfirm && studentConfirm)
            {
                studentService.AddStudentToClass(model.className, model.studentName);

                return Redirect(Url.Action("Index", "Classes"));
            }
            else
            {
               return Redirect(Url.Action("AddStudentsToClass", "Student"));
            }
        }



    }
}
