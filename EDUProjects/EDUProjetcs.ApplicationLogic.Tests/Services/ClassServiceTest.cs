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
    public class ClassServiceTest
    {
        private Mock<IClassRepository> classRepoMock = new Mock<IClassRepository>();
        private Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
        private Mock<IGradingRepository> gradingRepoMock = new Mock<IGradingRepository>();
        private Mock<IStudentRepository> studentRepoMock = new Mock<IStudentRepository>();
        private Mock<IEnrollRepository> enrollRepoMock = new Mock<IEnrollRepository>();

        private Guid existingClassId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
        private Guid existingProjectId = Guid.Parse("7299BFAC-4ASE-4A6D-99DF-57A4D6FBA712");

        private string existingClassName = "Materie1";

        [TestInitialize]
        public void InitializeTest()
        {


            var classes = new Class
            {
                Id = existingClassId,
                Subject_Title = "BlaBla",
                Description = "LastBlaBla",
                PassGrade = 5,
                Difficulty = 3,
                LevelRequirement = "bla",

            };

            classRepoMock.Setup(classRepo => classRepo.GetClassById(existingClassId))
                            .Returns(classes);

        }

       

        [TestMethod]
        public void GetClassByName_ThrowsEntityNotFound_WhenNameDoesNotExist()
        {
            //arrange
            var nonExistingClassName = "Bla";

            var classService = new ClassService(classRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                classService.GetClassByName(nonExistingClassName);
            });
        }

        [TestMethod]
        public void GetClassByName_Returns_WhenNameExists()
        {

            Exception throwException = null;
            var classService = new ClassService(classRepoMock.Object);
            Class classes = null;
            //act   
            try
            {
                classes = classService.GetClassByName(existingClassName);
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(classes);
        }

        [TestMethod]
        public void GetClassById_ThrowsException_WhenClassIdHasInvalidValue()
        {
            //arrange
            var classService = new ClassService(classRepoMock.Object);

            var badClassId = "jkajsdkasj dkj daksdj as";
            Guid badId = Guid.Parse(badClassId);

            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                classService.GetClassById(badId);
            });
        }

        [TestMethod]
        public void GetClassById_ThrowsEntityNotFound_WhenClassIdDoesNotExist()
        {
            //arrange
            var nonExistingClassId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";
            Guid nonExistingId = Guid.Parse(nonExistingClassId);

            var classService = new ClassService(classRepoMock.Object);
            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                classService.GetClassById(nonExistingId);
            });
        }

        [TestMethod]
        public void GetClassById_Returns_ClassIdWhenExists()
        {

            Exception throwException = null;
            var classService = new ClassService(classRepoMock.Object);
            Class classes = null;
            //act   
            try
            {
                Guid existingId = Guid.Parse(existingClassId.ToString());
                classes = classService.GetClassById(existingId);
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(classes);
        }


        [TestMethod]
        public void GetClassByProjectId_ThrowsException_WhenProjectIdHasInvalidValue()
        {
            //arrange
            var classService = new ClassService(classRepoMock.Object);

            var badProjectId = "jkajsdkasj dkj daksdj as";
            Guid badId = Guid.Parse(badProjectId);

            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                classService.GetClassByProjectId(badId);
            });
        }

        [TestMethod]
        public void GetClassByProjectId_ThrowsEntityNotFound_WhenProjectIdDoesNotExist()
        {
            //arrange
            var nonExistingProjectId = "7299FFCC-435E-4A6D-99DF-57A4D6DF4547";
            Guid nonExistingId = Guid.Parse(nonExistingProjectId);

            var classService = new ClassService(classRepoMock.Object);
            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                classService.GetClassByProjectId(nonExistingId);
            });
        }

        [TestMethod]
        public void GetClassByProjectId_Returns_ProjectIdWhenExists()
        {

            Exception throwException = null;
            var classService = new ClassService(classRepoMock.Object);
            Class classes = null;
            //act   
            try
            {
                Guid existingId = Guid.Parse(existingProjectId.ToString());
                classes = classService.GetClassByProjectId(existingId);
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(classes);
        }


    }
}

