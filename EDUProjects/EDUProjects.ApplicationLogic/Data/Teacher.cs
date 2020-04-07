using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Data
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Full_Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Address { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}
