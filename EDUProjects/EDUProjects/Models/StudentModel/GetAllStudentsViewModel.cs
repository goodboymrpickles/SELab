using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
namespace EDUProjects.Models.StudentModel
{
   
   public class GetAllStudentsViewModel
    {
        public IEnumerable<Student> Students { get; set; }
    }
}
