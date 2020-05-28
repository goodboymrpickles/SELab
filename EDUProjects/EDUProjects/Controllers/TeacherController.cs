using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUProjects.ApplicationLogic.Service;
using EDUProjects.Models.ClassModel;
using Microsoft.AspNetCore.Http;
using EDUProjects.Models.TeacherModel;
using Microsoft.AspNetCore.Identity;
using EDUProjects.ApplicationLogic.Services;
using EDUProjects.Models.StudentModel;
using EDUProjects.ApplicationLogic.Data;

namespace EDUProjects.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherService teacherService;

        private readonly RegisterService registerService;

        private readonly ClassService classService;
        private readonly StudentService studentService;

        public TeacherController(TeacherService teacherService, RegisterService registerService, ClassService classService, StudentService studentService)
        {
            this.teacherService = teacherService;
            this.registerService = registerService;
            this.classService = classService;
            this.studentService = studentService;
        }

        public ActionResult ViewTeacher()
        {
            try
            {
                var teachers = teacherService.GetAll();

                return View(new GetAllTeachersViewModel { Teachers = teachers });
            }
            catch(Exception)
            {
                return BadRequest("Invalid request received");
            }

        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeacher([FromForm] AddTeacherViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            registerService.AddTeacher(model.FullName, model.department, model.email, model.birthdate, model.address);

            return Redirect(Url.Action("Index","TeacherRegister"));
        }


        [HttpGet]
        public IActionResult AddStudentsToClass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudentsToClass([FromForm] AddStudentViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            studentService.AddStudent(model.FullName);

            return Redirect(Url.Action("Index", "Classes"));
        }



    }
}


