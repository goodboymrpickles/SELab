using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Data
{
    public class Project
    {
        public Guid Id { get; set;  }
        public DateTime Deadline { get; set; }
        public string Requirements { get; set; }
        public string Annexes { get; set; }
        public string Project_Title { get; set; }

  
    }
}
