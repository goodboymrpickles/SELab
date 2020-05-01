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

        [HttpGet]
        public IActionResult AddClass()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult DeleteClass()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult UpdateClass()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult AddClass([FromForm]AddClassViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            classService.AddClass(model.Subject_Title, model.Description);

            return Redirect(Url.Action("Index", "Class"));

        }

        //[HttpPost]
        //public IActionResult DeleteClass(Guid id)
        //{
        //    classService.DeleteClass(id);
        //    return Redirect(Url.Action("Index", "Class"));
        //}

        //[HttpPost]
        //public IActionResult UpdateClass([FromForm]UpdateTripViewModel model, Guid id)
        //{
        //    model.ClassId = id;

        //    //if (!ModelState.IsValid)
        //    //{

        //    //    return BadRequest();
        //    //}

        //    classService.UpdateClass(model.ClassId, model.Subject_Title, model.Description);
        //    return Redirect(Url.Action("Index", "Class"));
        //}
    }
}
