using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using HealthLinkApi.Controllers;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
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
        public async Task GetByIdAsync_ReturnsOkResult_WhenDoctorExists()
        {
            // Arrange
            int doctorId = 1;
            Doctor doctor = new Doctor { Id = doctorId, Name = "John Doe" };
            mockDoctorRepository.Setup(repo => repo.GetByIdAsync(doctorId)).ReturnsAsync(doctor);

            // Act
            var result = await doctorController.GetByIdAsync(doctorId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(doctor, okResult.Value);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsNotFoundResult_WhenDoctorDoesNotExist()
        {
            // Arrange
            int doctorId = 1;
            mockDoctorRepository.Setup(repo => repo.GetByIdAsync(doctorId)).ReturnsAsync((Doctor)null);

            // Act
            var result = await doctorController.GetByIdAsync(doctorId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}