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
    public class StudentServiceTest
    {
        private Mock<IStudentRepository> studentRepoMock = new Mock<IStudentRepository>();
        private Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
        private Mock<IClassRepository> classRepoMock = new Mock<IClassRepository>();
        private Mock<IGradingRepository> gradingRepoMock = new Mock<IGradingRepository>();
        private Mock<IEnrollRepository> enrollRepoMock = new Mock<IEnrollRepository>();

        private Guid existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");

        private string existingStudentEmail = "ajs@yahoo.com";


        [TestInitialize]
        public void InitializeTest()
        {


            var student = new Student
            {
                Id = existingUserId,
                Email = "blabla@mail.com",
                Name = "BlaBla",
                University = "LastBlaBla",
                Section = "Blabla",
                Phone_Number = "0657",
                Birth_Date = new DateTime(2010, 8, 18),
                Address = "Strada",

            };

            studentRepoMock.Setup(studentRepo => studentRepo.GetStudentById(existingUserId))
                            .Returns(student);

        }

        [TestMethod]
        public void GetStudentById_ThrowsException_WhenUserIdHasInvalidValue()
        {
            //arrange
            //ITeacherRepository teacherRepository, ICourseRepository
            var teacherService = new StudentService(studentRepoMock.Object, enrollRepoMock.Object, classRepoMock.Object, gradingRepoMock.Object, teacherRepoMock.Object);

            var badUserId = "jkajsdkasj dkj daksdj as";
            Guid badId = Guid.Parse(badUserId);

            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                teacherService.GetStudentById(badId);
            });
        }

        [TestMethod]
        public void GetStudentById_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            //arrange
            var nonExistingUserId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";
            Guid nonExistingId = Guid.Parse(nonExistingUserId);

            var studentService = new StudentService(studentRepoMock.Object, enrollRepoMock.Object, classRepoMock.Object, gradingRepoMock.Object, teacherRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                studentService.GetStudentById(nonExistingId);
            });
        }

        [TestMethod]
        public void GetStudentById_Returns_UserWhenExists()
        {

            Exception throwException = null;
            var studentService = new StudentService(studentRepoMock.Object, enrollRepoMock.Object, classRepoMock.Object, gradingRepoMock.Object, teacherRepoMock.Object);
            Student user = null;
            //act   
            try
            {
                Guid existingId = Guid.Parse(existingUserId.ToString());
                user = studentService.GetStudentById(existingId);
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
        public void GetStudentByEmail_ThrowsEntityNotFound_WhenEmailDoesNotExist()
        {
            //arrange
            var nonExistingStudentEmail = "Bla@hy.ocm";

            var studentService = new StudentService(studentRepoMock.Object, enrollRepoMock.Object, classRepoMock.Object, gradingRepoMock.Object, teacherRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                studentService.GetStudentByEmail(nonExistingStudentEmail);
            });
        }

        [TestMethod]
        public void GetStudentByEmail_Returns_EmailWhenExists()
        {

            Exception throwException = null;
            var studentService = new StudentService(studentRepoMock.Object, enrollRepoMock.Object, classRepoMock.Object, gradingRepoMock.Object, teacherRepoMock.Object);
            Student student = null;
            //act   
            try
            {
                student = studentService.GetStudentByEmail(existingStudentEmail);
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(student);
        }
    }
}
