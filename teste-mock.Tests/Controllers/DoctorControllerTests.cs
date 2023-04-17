using Domain.Entities;
using Domain.Interfaces;
using HealthLinkApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace teste_mock.Tests.Controllers
{
    public class DoctorControllerTests
    {
        private Mock<IDoctor> mockDoctorRepository;
        private DoctorController doctorController;

        public DoctorControllerTests()
        {
            mockDoctorRepository = new Mock<IDoctor>();
            doctorController = new DoctorController(mockDoctorRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOkResult_WithListOfDoctors()
        {
            // Arrange
            List<Doctor> doctors = new List<Doctor>
            {
                new Doctor { Id = 1, Name = "Wilson Picket" },
                new Doctor { Id = 2, Name = "Ottis Redding" },
                new Doctor { Id = 3, Name = "James Brown" }
            };

            mockDoctorRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(doctors);

            // Act
            var result = await doctorController.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Doctor>>(okResult.Value);
            Assert.Equal(doctors.Count, model.Count());
        }

    }
}