﻿using Domain.Entities;
using Domain.Interfaces;
using HealthLinkApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace teste_mock.Tests.Controllers
{
    public sealed class PatientControllerTests
    {
        private Mock<IPatient> mockPatientRepository;
        private PatientController patientController;

        public PatientControllerTests()
        {
            mockPatientRepository = new Mock<IPatient>();
            patientController = new PatientController(mockPatientRepository.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOkResult_WithListOfPatient()
        {
            //Arrange
            List<Patient> patient = new List<Patient>
            {
                new Patient { Id = 1, Name = "Colle Porter"},
                new Patient { Id = 2, Name = "Marvin Gaye"},
                new Patient { Id = 3, Name = "BB King"},
            };

            mockPatientRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(patient);

            //Act
            var result = await patientController.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Patient>> (okResult.Value);
            Assert.Equal(patient.Count, model.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFound_WhenPatientNotFound()
        {
            //Arrange
            int id = 1;
            Patient patient = null;
            mockPatientRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(patient);

            //Act
            var result = await patientController.GetByIdAsync(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkResult_WithPatient()
        {
            // Arrange
            int id = 1;
            Patient patient = new Patient { Id = 1, Name = "Colle Porter" };
            mockPatientRepository.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(patient);

            // Act
            var result = await patientController.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Patient>(okResult.Value);
            Assert.Equal(patient, model);
        }

        [Fact]
        public async Task CreateAsync_ReturnsCreatedAction_WithNewPatient()
        {
            //Arrange
            Patient newPatient = new Patient { Id = 1, Name = "Colle Porter" };

            mockPatientRepository.Setup(x => x.CreateAsync(It.IsAny<Patient>())).Returns(Task.CompletedTask);

            // Act
            var result = await patientController.CreateAsync(newPatient);

            //Assert
            Assert.NotNull(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(patientController.GetByIdAsync), createdAtActionResult.ActionName);
            var routeValues = new RouteValueDictionary(createdAtActionResult.RouteValues);
            Assert.Equal(newPatient.Id, routeValues["id"]);
            Assert.Equal(newPatient, createdAtActionResult.Value);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsNoContentResult_AfterUpdatingPatient()
        {
            // Arrange
            int id = 1;
            Patient patientToUpdate = new Patient { Id = id, Name = "Marvin Gaye" };

            mockPatientRepository.Setup(repo => repo.UpdateAsync(id, It.IsAny<Patient>())).Returns(Task.CompletedTask);

            // Act
            var result = await patientController.UpdateAsync(id, patientToUpdate);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsNoContentResult_AfterDeletingPatient()
        {
            // Arrange
            int id = 1;

            mockPatientRepository.Setup(repo => repo.DeleteAsync(id)).Returns(Task.CompletedTask);

            // Act
            var result = await patientController.DeleteAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task SearchByNameAsync_ReturnsOkResult_WithPatients()
        {
            // Arrange
            string name = "Marvin";

            // Configurar o mock do IPatient para retornar uma lista fictícia de pacientes
            var patients = new List<Patient> { new Patient { Id = 1, Name = "Marvin Gaye" }, new Patient { Id = 2, Name = "BB King" } };
            mockPatientRepository.Setup(repo => repo.SearchByNameAsync(name)).ReturnsAsync(patients);

            // Act
            var result = await patientController.SearchByNameAsync(name);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult.Value);
            var returnedPatients = okResult.Value as List<Patient>;
            Assert.Equal(2, returnedPatients.Count);
            // Faça mais verificações nos dados retornados, se necessário
        }

        [Fact]
        public async Task GetPatientsByDoctorIdAsync_ReturnsOkResult_WithPatients()
        {
            // Arrange
            int doctorId = 1;

            // Configurar o mock do IPatient para retornar uma lista fictícia de pacientes
            var patients = new List<Patient> { new Patient { Id = 1, Name = "Marvin Gaye" }, new Patient { Id = 2, Name = "BB King" } };
            mockPatientRepository.Setup(repo => repo.GetPatientsByDoctorIdAsync(doctorId)).ReturnsAsync(patients);

            // Act
            var result = await patientController.GetPatientsByDoctorIdAsync(doctorId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult.Value);
            var returnedPatients = okResult.Value as List<Patient>;
            Assert.Equal(2, returnedPatients.Count);
            // Faça mais verificações nos dados retornados, se necessário
        }
    }
}
