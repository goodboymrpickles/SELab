using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUProjects.ApplicationLogic.Service;
using EDUProjects.Models.ClassModel;
using Microsoft.AspNetCore.Http;
using EDUProjects.Models.TeacherModel;

namespace EDUProjects.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherService teacherService;

        public TeacherController(TeacherService teacherService)
        {
            this.teacherService = teacherService;
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
    }
}
