using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Data
{
    public class Grading
    {
        public Guid Id { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
        public int Grade { get; set; }
        public string Feedback { get; set; }
        public bool Is_Passed { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
