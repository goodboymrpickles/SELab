using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUProjects.Models.ClassModel
{
    public class GetAllClassesViewModel
    {
        public IEnumerable<Class> Classes { get; set; }
    }
}
