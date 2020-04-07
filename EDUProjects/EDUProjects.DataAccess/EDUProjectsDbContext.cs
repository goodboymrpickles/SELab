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
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grading> Gradings { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Project> Projects { get; set; }


    

    }
}
