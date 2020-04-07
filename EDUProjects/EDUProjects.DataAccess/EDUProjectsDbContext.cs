using EDUProjects.ApplicationLogic.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.DataAccess
{
    public class EDUProjectsDbContext: DbContext
    {
        public EDUProjectsDbContext(DbContextOptions<EDUProjectsDbContext> options) : base(options)
        {

        }

    }
}
