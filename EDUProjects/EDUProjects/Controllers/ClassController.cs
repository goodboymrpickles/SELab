using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDUProjects.ApplicationLogic.Services;
using EDUProjects.Models.ClassModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDUProjects.Controllers
{

    public class ClassController : Controller
    {
        private readonly ClassService classService;


        public ClassController(ClassService classService)
        {

            this.classService = classService;
        }

        // GET: Class
        public ActionResult Index()
        {
            try
            {
                var classes = classService.GetAll();

                return View(new GetAllClassesViewModel { Classes = classes });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

    }
}
