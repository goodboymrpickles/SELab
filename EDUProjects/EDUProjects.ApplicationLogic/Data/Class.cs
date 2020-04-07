using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Data
{
    public class Class
    {
        public Guid Id { get; set; }
        public string Subject_Title { get; set; }
        public string Description { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
