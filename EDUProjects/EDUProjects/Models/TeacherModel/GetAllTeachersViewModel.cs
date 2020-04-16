using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUProjects.Models.TeacherModel
{
    public class GetAllTeachersViewModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
