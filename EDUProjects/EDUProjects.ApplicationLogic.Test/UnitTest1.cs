using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDUProjects.ApplicationLogic.Data;
using System;

namespace EDUProjects.ApplicationLogic.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDifficultyComputeVeryEasy()
        {
            var newClass = new Class()
            {
                Id = new Guid(),
                SubjectTitle = "Test",
                Description = "Test description",
                Difficulty = 1,
                PassGrade = 6,
                LevelRequirement = "Beginner"
            };

            Assert.AreEqual("Very Easy", newClass.ComputeOverallDifficulty());
        }

        [TestMethod]
        public void TestDifficultyComputeEasy()
        {
            var newClass = new Class()
            {
                Id = new Guid(),
                SubjectTitle = "Test",
                Description = "Test description",
                Difficulty = 1,
                PassGrade = 6,
                LevelRequirement = "Intermediate"
            };

            Assert.AreEqual("Easy", newClass.ComputeOverallDifficulty());
        }

        [TestMethod]
        public void TestDifficultyComputeMedium()
        {
            var newClass = new Class()
            {
                Id = new Guid(),
                SubjectTitle = "Test",
                Description = "Test description",
                Difficulty = 2,
                PassGrade = 6,
                LevelRequirement = "Intermediate"
            };

            Assert.AreEqual("Medium", newClass.ComputeOverallDifficulty());
        }

        [TestMethod]
        public void TestDifficultyComputeHard()
        {
            var newClass = new Class()
            {
                Id = new Guid(),
                SubjectTitle = "Test",
                Description = "Test description",
                Difficulty = 3,
                PassGrade = 6,
                LevelRequirement = "Intermediate"
            };

            Assert.AreEqual("Hard", newClass.ComputeOverallDifficulty());
        }

        [TestMethod]
        public void TestDifficultyComputeVeryHard()
        {
            var newClass = new Class()
            {
                Id = new Guid(),
                SubjectTitle = "Test",
                Description = "Test description",
                Difficulty = 3,
                PassGrade = 6,
                LevelRequirement = "Advanced"
            };

            Assert.AreEqual("Very Hard", newClass.ComputeOverallDifficulty());
        }

        [TestMethod]
        public void TestDifficultyComputeImplicationRate()
        {
            var newClass = new Class()
            {
                Id = new Guid(),
                SubjectTitle = "Test",
                Description = "Test description",
                Difficulty = 3,
                PassGrade = 6,
                LevelRequirement = "Advanced"
            };

            Assert.AreEqual(4, newClass.ComputeImplicationRate());
        }

        [TestMethod]
        public void TestChangeRequirement()
        {
            var newClass = new Class()
            {
                Id = new Guid(),
                SubjectTitle = "Test",
                Description = "Test description",
                Difficulty = 3,
                PassGrade = 6,
                LevelRequirement = "Advanced"
            };

            newClass.ChangeRequirement(10, "Beginner");

            var newClassChanged = new Class()
            {
                Id = new Guid(),
                SubjectTitle = "Test",
                Description = "Test description",
                Difficulty = 1,
                PassGrade = 10,
                LevelRequirement = "Beginner"
            };

            newClass.ComputeImplicationRate();
            
            Assert.AreEqual( newClassChanged.PassGrade , newClass.PassGrade);
            Assert.AreEqual(newClassChanged.LevelRequirement, newClass.LevelRequirement);
        }
    }
}
