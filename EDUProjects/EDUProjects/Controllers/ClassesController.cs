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

    public class ClassesController : Controller
    {
        private readonly ClassService classService;


        public ClassesController(ClassService classService)
        {

            this.classService = classService;
        }

        // GET: Class
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "subjectTitle_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Description" ? "description_desc" : "Description";

            try
            {
                var classes = classService.GetAll();

                if (!String.IsNullOrEmpty(searchString))
                {
                    classes = classes.Where(s => s.SubjectTitle.Contains(searchString)
                                           || s.Description.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "subjectTitle_desc":
                        classes = classes.OrderByDescending(s => s.SubjectTitle);
                        break;
                    case "Description":
                        classes = classes.OrderBy(s => s.Description);
                        break;
                    case "description_desc":
                        classes = classes.OrderByDescending(s => s.Description);
                        break;
                    default:
                        classes = classes.OrderBy(s => s.SubjectTitle);
                        break;
                }

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

        [HttpGet]
        public IActionResult DeleteClass([FromRoute]Guid id)
        {
            //create instance
            var deleteVM = new DeleteClassViewModel { Id = id, SubjectName = classService.GetClassName(id) };
            return View(deleteVM);
        }

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

            return Redirect(Url.Action("Index", "Classes"));

        }

        [HttpPost]
        public IActionResult DeleteClass(DeleteClassViewModel delVM)
        {
            classService.DeleteClass(delVM.Id);
            return Redirect(Url.Action("Index", "Classes"));
        }

        //[HttpPost]
        //public IActionResult UpdateClass([FromForm]UpdateTripViewModel model, Guid id)
        //{
        //    model.ClassId = id;

        //    if (!ModelState.IsValid)
        //    {

        //        return BadRequest();
        //    }

        //    classService.UpdateClass(model.ClassId, model.Subject_Title, model.Description);
        //    return Redirect(Url.Action("Index", "Class"));
        //}
    }
}
