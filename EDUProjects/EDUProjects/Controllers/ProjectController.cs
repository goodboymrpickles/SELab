using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;
using EDUProjects.ApplicationLogic.Service;
using EDUProjects.ApplicationLogic.Services;
using EDUProjects.Models.ClassModel;
using EDUProjects.Models.ProjectModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EDUProjects.Controllers
{

    public class ProjectController : Controller
    {
        private readonly ProjectService projectService;
        private readonly TeacherService teacherService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly StudentService studentService;

        public ProjectController(ProjectService projectService,TeacherService teacherService, UserManager<IdentityUser> userManager, StudentService studentService)
        {
            this.projectService = projectService;
            this.teacherService = teacherService;
            this.userManager = userManager;
            this.studentService = studentService;
        }

      


        public ActionResult Index()
        {
            try
            {
                var projects = projectService.GetAll();

                return View(new GetAllProjectsViewModel { Projects = projects });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }
        [HttpGet]
        public IActionResult AddProject()
        {
            return View();
        }
        public IActionResult StudentIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }

         [HttpPost]

         public IActionResult AddComment([FromForm]AddCommentViewModel model)
          {
         if (!ModelState.IsValid)
         {

           return BadRequest();

        }
            var user = userManager.GetUserName(User);
            teacherService.AddComment(model.Feedback, model.grade, user);



         return Redirect(Url.Action("Index", "Feedback"));

        }


        [HttpGet]
        public IActionResult AddCommentStudent()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddCommentStudent([FromForm]AddCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();

            }
            var user = userManager.GetUserName(User);

            studentService.AddCommentStudent(model.Feedback, user);



            return Redirect(Url.Action("AddProject", "Project"));

        }


        [HttpPost]
        public IActionResult AddProject([FromForm]AddProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            projectService.AddProject(model.Project_Title);

            return Redirect(Url.Action("Index", "Project"));

        }
    }
}
