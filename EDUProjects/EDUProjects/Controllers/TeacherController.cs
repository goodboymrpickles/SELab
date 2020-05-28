using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUProjects.ApplicationLogic.Service;
using EDUProjects.Models.ClassModel;
using Microsoft.AspNetCore.Http;
using EDUProjects.Models.TeacherModel;
using EDUProjects.Areas.Identity.Pages.Account;

namespace EDUProjects.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherService teacherService;

        private readonly RegisterService registerService;

        public TeacherController(TeacherService teacherService, RegisterService registerService)
        {
            this.teacherService = teacherService;
            this.registerService = registerService;
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
    }
}
