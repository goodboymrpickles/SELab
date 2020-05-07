using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUProjects.ApplicationLogic.Service;
using EDUProjects.ApplicationLogic.Services;
using EDUProjects.Models.ClassModel;
using EDUProjects.Models.ProjectModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDUProjects.Controllers
{

    public class ProjectController : Controller
    {
        private readonly ProjectService projectService;
        private readonly TeacherService teacherService;


        public ProjectController(ProjectService projectService)
        {
            this.projectService = projectService;
        }

        public ProjectController(TeacherService teacherService)
        {
            this.teacherService = teacherService;
        }


        public ActionResult Index()
        {
            try
            {
                var projects = projectService.GetAll();

                return View(new TeacherProjectViewModel { Projects = projects });
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
        public ActionResult StudentIndex()
        {
            try
            {
                var projects = projectService.GetAll();

                return View(new TeacherProjectViewModel { Projects = projects });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
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

          teacherService.AddComment(model.Feedback);



         return Redirect(Url.Action("Index", "Feedback"));

        }

        [HttpGet]
        public IActionResult AddGrade()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGrade([FromForm]AddGradeViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            projectService.AddGrade(model.Grade);

            return Redirect(Url.Action("Index", "Project"));

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
