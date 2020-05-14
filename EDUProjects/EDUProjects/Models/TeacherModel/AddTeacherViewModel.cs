using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUProjects.Models.TeacherModel
{
    public class AddTeacherViewModel
    {
        public string FullName { get; set; }

        public string department { get; set; }
        public string email { get; set; }
        public DateTime birthdate { get; set; }
        public string address { get; set; }
    }
}
