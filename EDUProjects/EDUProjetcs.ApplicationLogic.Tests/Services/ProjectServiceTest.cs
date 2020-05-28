using CourseManager.ApplicationLogic.Exceptions;
using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using EDUProjects.ApplicationLogic.Service;
using EDUProjects.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjetcs.ApplicationLogic.Tests.Services
{
    public class ProjectServiceTest
    {
        private Mock<IProjectRepository> projectRepoMock = new Mock<IProjectRepository>();
        private Mock<IGradingRepository> gradingRepoMock = new Mock<IGradingRepository>();

        private Guid existingProjectId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");

        [TestInitialize]
        public void InitializeTest()
        {


            var project = new Project
            {
                Id = existingProjectId,
                Deadline = new DateTime(2010, 8, 18),
                Requirements = "LastBlaBla",
                Annexes = "blalal",
                Project_Title = "Bla",

            };

            projectRepoMock.Setup(projectRepo => projectRepo.GetProjectById(existingProjectId))
                            .Returns(project);

        }



        [TestMethod]
        public void GetProjectById_ThrowsException_WhenUserIdHasInvalidValue()
        {
            //arrange
            //ITeacherRepository teacherRepository, ICourseRepository
            var projectService = new ProjectService(projectRepoMock.Object, gradingRepoMock.Object);

            var badProjectId = "jkajsdkasj dkj daksdj as";
            Guid badId = Guid.Parse(badProjectId);

            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                projectService.GetProjectById(badId);
            });
        }

        [TestMethod]
        public void GetProjectById_ThrowsEntityNotFound_WhenProjectDoesNotExist()
        {
            //arrange
            var nonExistingProjectId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";
            Guid nonExistingId = Guid.Parse(nonExistingProjectId);

            var projectService = new ProjectService(projectRepoMock.Object, gradingRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                projectService.GetProjectById(nonExistingId);
            });
        }

        [TestMethod]
        public void GetByProjectId_Returns_ProjectWhenExists()
        {

            Exception throwException = null;
            var projectService = new ProjectService(projectRepoMock.Object, gradingRepoMock.Object);
            Project project = null;
            //act   
            try
            {
                Guid existingId = Guid.Parse(existingProjectId.ToString());
                project = projectService.GetProjectById(existingId);
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(project);
        }
    }
}


