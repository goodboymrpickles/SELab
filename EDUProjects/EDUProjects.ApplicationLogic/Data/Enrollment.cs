using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Data
{
    public class Enrollment
    {
        public Guid Id { get; set; } 
        public ICollection<Student> Students { get; set; }
        public ICollection<Class> Classes { get; set; }

    }
}
