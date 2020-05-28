using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDUProjects.Models.ProjectModel
{
    public class GetAllProjectsViewModel
    {
      
            public IEnumerable<Project> Projects { get; set; }
        
    }

}

