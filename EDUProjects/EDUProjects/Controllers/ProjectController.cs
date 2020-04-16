using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUProjects.ApplicationLogic.Service;
using EDUProjects.ApplicationLogic.Services;
using EDUProjects.Models.ProjectModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDUProjects.Controllers
{

    public class ProjectController : Controller
    {
        private readonly ProjectService projectService;


        public ProjectController(ProjectService projectService)
        {
            this.projectService = projectService;
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

    }
}
