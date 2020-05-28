using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUProjects.Models.StudentModel
{
    public class AddStudentViewModel
    {
        public string FullName { get; set; }

        public string University { get; set; }

        public string Section { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone_Number { get; set; }

        public string Address { get; set; }

        public Student Student { get; set; }

    }
}
