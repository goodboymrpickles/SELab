using EDUProjects.ApplicationLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using EDUProjects.ApplicationLogic.Data;
using EDUProjects.ApplicationLogic.Services;
using CourseManager.ApplicationLogic.Exceptions;

namespace EDUProjects.ApplicationLogic.Test.Services
{
    [TestClass]
    public class ClassServiceTest
    {
        private Mock<IProjectRepository> projectRepoMock = new Mock<IProjectRepository>();
        private Mock<IClassRepository> classRepoMock = new Mock<IClassRepository>();
        private Guid existingProjectId = Guid.Parse("71BC4766-B4DF-40DC-A084-134C153D2167");
        private Guid existingClassId = Guid.Parse("F3B878A2-9748-4EFC-966D-B125475C885C");
        private Class _oneClass;

        [TestInitialize]
        public void InitializeTest()
        {
            var project1 = new Project
            {
                Id = existingProjectId,
                Requirements = "English",
                Project_Title = "The history of Romans"
            };

            var project2 = new Project
            {
                Id = Guid.NewGuid(),
                Requirements = "German",
                Project_Title = "The history of the Nazi Empire"
            };

            var project3 = new Project
            {
                Id = Guid.NewGuid(),
                Requirements = "French",
                Project_Title = "The history of the baguette"
            };

            var projectsHistory = new List<Project>();
            projectsHistory.Add(project1);
            projectsHistory.Add(project2);
            projectsHistory.Add(project3);

            var oneClass = new Class
            {
                Id = existingClassId,
                SubjectTitle = "History",
                Description = "This is a class about the history of the world",
                Projects = projectsHistory
            };

            var project4 = new Project
            {
                Id = Guid.NewGuid(),
                Requirements = "French",
                Project_Title = "Verb conjugations"
            };
            
            var project5 = new Project
            {
                Id = Guid.NewGuid(),
                Requirements = "French",
                Project_Title = "Vocabulary"
            };

            var projectsFrench = new List<Project>();
            projectsFrench.Add(project4);
            projectsFrench.Add(project5);

            var secondClass = new Class
            {
                Id = Guid.NewGuid(),
                SubjectTitle = "French",
                Description = "This is a class about the study of the french language ",
                Projects = projectsFrench
            };
           
            classRepoMock.Setup(classRepoMock => classRepoMock.GetClassByProjectId(existingProjectId))
               .Returns(oneClass);

            classRepoMock.Setup(classRepoMock => classRepoMock.GetClassById(existingClassId))
                           .Returns(oneClass);
        

            _oneClass = oneClass;
        }

        [TestMethod]
        public void GetClassByProjectId_ThrowsException_WhenProjectIdHasInvalidValue()
        {
            //arrange
            var classService = new ClassService(classRepoMock.Object, projectRepoMock.Object);

            var badProjectId = "this is a bad project id";
            //act            
            //assert
            Assert.ThrowsException<Exception>(() =>
            {
                classService.GetClassByProjectId(badProjectId);
            });
        }

        [TestMethod]
        public void GetClassByProjectId_Returns_ClassWhenExist()
        {
            //arrange
            Exception throwException = null;
            var classService = new ClassService(classRepoMock.Object, projectRepoMock.Object);

            Class oneClass= null;
            //act   
            try
            {
                 oneClass = classService.GetClassByProjectId(existingProjectId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(oneClass);
        }

        [TestMethod]
        public void GetClassByProjectId_ThrowsException_WhenProjectDoesNotExist()
        {
            //arrange
            var classService = new ClassService(classRepoMock.Object, projectRepoMock.Object);

            var nonexistingProjectId = "52803153-8E28-476D-9271-E6E40B634682";
            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                classService.GetClassByProjectId(nonexistingProjectId);
            });

        }

        [TestMethod]
        public void GetClassById_Returns_ClassWhenExists()
        {
            //arrange
            Exception throwException = null;
            var classService = new ClassService(classRepoMock.Object, projectRepoMock.Object);

            Class oneClass = null;
            //act   
            try
            {
                oneClass = classService.GetClassById(existingClassId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(oneClass);
        }

        [TestMethod]
        public void GetClassById_ThrowsException_WhenClassIdHasInvalidValue()
        {
            //arrange
            var classService = new ClassService(classRepoMock.Object, projectRepoMock.Object);

            var badClassId = "this is a bad class id";
            //act            
            //assert
            Assert.ThrowsException<Exception>(() =>
            {
                classService.GetClassById(badClassId);
            });

        }

        [TestMethod]
        public void GetClassById_ThrowsException_WhenClassDoesNotExist()
        {
            //arrange
            var classService = new ClassService(classRepoMock.Object, projectRepoMock.Object);

            var nonexistingClassId = "414A9FAC-58F4-4B5C-A323-5E5391217B5D";
            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                classService.GetClassById(nonexistingClassId);
            });

        }    
    }
}



