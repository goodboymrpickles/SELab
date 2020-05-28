using CourseManager.ApplicationLogic.Exceptions;
using EDUProjects.ApplicationLogic.Abstractions;
using EDUProjects.ApplicationLogic.Data;
using EDUProjects.ApplicationLogic.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjetcs.ApplicationLogic.Tests.Services
{
    public class TeacherServiceTest
    {
        private Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
        private Mock<IClassRepository> classRepoMock = new Mock<IClassRepository>();
        private Mock<IGradingRepository> gradingRepoMock = new Mock<IGradingRepository>();
        private Mock<IStudentRepository> studentRepoMock = new Mock<IStudentRepository>();
        private Mock<IEnrollRepository> enrollRepoMock = new Mock<IEnrollRepository>();

        private Guid existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");

        private string existingClassName = "Materie1";

        [TestInitialize]
        public void InitializeTest()
        {


            var teacher = new Teacher
            {
                Id = existingUserId,
                Email = "blabla@mail.com",
                Full_Name = "BlaBla",
                Department = "LastBlaBla",
                Birth_Date = new DateTime(2010, 8, 18),
                Address = "Strada",

            };

            teacherRepoMock.Setup(teacherRepo => teacherRepo.GetTeacherById(existingUserId))
                            .Returns(teacher);

        }

        [TestMethod]
        public void GetTeacherById_ThrowsException_WhenUserIdHasInvalidValue()
        {
            //arrange
            //ITeacherRepository teacherRepository, ICourseRepository
            var teacherService = new TeacherService(teacherRepoMock.Object, gradingRepoMock.Object, classRepoMock.Object, studentRepoMock.Object, enrollRepoMock.Object);

            var badUserId = "jkajsdkasj dkj daksdj as";
            Guid badId = Guid.Parse(badUserId);
        
            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                teacherService.GetTeacherById(badId);
            });
        }

        [TestMethod]
        public void GetTeacherById_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            //arrange
            var nonExistingUserId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";
            Guid nonExistingId = Guid.Parse(nonExistingUserId);

            var teacherService = new TeacherService(teacherRepoMock.Object, gradingRepoMock.Object, classRepoMock.Object, studentRepoMock.Object, enrollRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                teacherService.GetTeacherById(nonExistingId);
            });
        }

        [TestMethod]
        public void GetTeacherById_Returns_UserWhenExists()
        {

            Exception throwException = null;
            var teacherService = new TeacherService(teacherRepoMock.Object, gradingRepoMock.Object, classRepoMock.Object, studentRepoMock.Object, enrollRepoMock.Object);
            Teacher user = null;
            //act   
            try
            {
                Guid existingId = Guid.Parse(existingUserId.ToString());
                user = teacherService.GetTeacherById(existingId);
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(user);
        }


        [TestMethod]
        public void GetTeacherByEmail_ThrowsEntityNotFound_WhenEmailDoesNotExist()
        {
            //arrange
            var nonExistingTeacherEmail = "Bla@hy.ocm";

            var teacherService = new TeacherService(teacherRepoMock.Object, gradingRepoMock.Object, classRepoMock.Object, studentRepoMock.Object, enrollRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                teacherService.GetTeacherByEmail(nonExistingTeacherEmail);
            });
        }

        [TestMethod]
        public void GetTeacherByEmail_Returns_EmailWhenExists()
        {

            Exception throwException = null;
            var teacherService = new TeacherService(teacherRepoMock.Object, gradingRepoMock.Object, classRepoMock.Object, studentRepoMock.Object, enrollRepoMock.Object);
            Teacher teacher = null;
            //act   
            try
            {
                teacher = teacherService.GetTeacherByEmail(existingClassName);
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(teacher);
        }
    }
}

