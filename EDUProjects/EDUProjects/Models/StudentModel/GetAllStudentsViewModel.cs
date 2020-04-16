using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUProjects.Models.StudentModel
{
   
   public class GetAllStudentsViewModel
    {
        public IEnumerable<Student>Students { get; set; }
    }
}
