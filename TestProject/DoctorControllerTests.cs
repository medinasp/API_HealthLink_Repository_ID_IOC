using Domain.Entities;
using Domain.Interfaces;
using HealthLinkApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestProject
{
    [TestClass]
    public class DoctorControllerTests
    {
        private Mock<IDoctor> mockDoctorRepository;
        private DoctorController doctorController;

        [TestInitialize]
        public void TestInitialize()
        {
            mockDoctorRepository = new Mock<IDoctor>();
            doctorController = new DoctorController(mockDoctorRepository.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsOkResult_WithListOfDoctors()
        {
            // Arrange
            List<Doctor> doctors = new List<Doctor>
            {
                new Doctor { Id = 1, Name = "John Doe" },
                new Doctor { Id = 2, Name = "Jane Smith" },
                new Doctor { Id = 3, Name = "Michael Brown" }
            };
            mockDoctorRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(doctors);

            // Act
            var result = await doctorController.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(doctors, okResult.Value);
        }
    }
}