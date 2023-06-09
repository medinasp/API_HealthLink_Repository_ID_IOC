﻿using Domain.Entities;
using Domain.Interfaces;
using HealthLinkApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace teste_mock.Tests.Controllers
{
    public class AppointmentControllerTests
    {
        private Mock<IAppointment> mockAppointmentRepository;
        private AppointmentController appointmentController;

        public AppointmentControllerTests()
        {
            mockAppointmentRepository = new Mock<IAppointment>();
            appointmentController = new AppointmentController(mockAppointmentRepository.Object);
        }

        [Fact]

        public async Task GetAllAsync_ReturnsOkResult_WithListOfPatient()
        {
            // Arrange
            List<Appointment> appointment = new List<Appointment>
            {
                new Appointment { Id = 1, DateTime = DateTime.Now, PatientId = 1, DoctorId = 1 },
                new Appointment { Id = 2, DateTime = DateTime.Now, PatientId = 2, DoctorId = 2 },
                new Appointment { Id = 3, DateTime = DateTime.Now, PatientId = 3, DoctorId = 3}
            };

            mockAppointmentRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(appointment);

            // Act
            var result = await appointmentController.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Appointment>>(okResult.Value);
            Assert.Equal(appointment.Count, model.Count());
            Assert.Equal(appointment, model);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsAppointment_WhenValidId()
        {
            // Arrange
            int id = 1;
            Appointment appointment = new Appointment { Id = id, DateTime = DateTime.Now, PatientId = 1, DoctorId = 1 };
            mockAppointmentRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(appointment);

            // Act
            var result = await appointmentController.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Appointment>(okResult.Value);
            Assert.Equal(appointment, model);
        }

        [Fact]
        public async Task CreateAsync_ReturnsCreatedAtAction_WithAppointment()
        {
            // Arrange
            Appointment appointment = new Appointment { Id = 1, DateTime = DateTime.Now, PatientId = 1, DoctorId = 1 };
            mockAppointmentRepository.Setup(x => x.CreateAsync(It.IsAny<Appointment>())).Returns(Task.CompletedTask);

            // Act
            var result = await appointmentController.CreateAsync(appointment);

            // Assert
            Assert.NotNull(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(appointmentController.GetByIdAsync), createdAtActionResult.ActionName);
            Assert.Equal(appointment.Id, createdAtActionResult.RouteValues["id"]);
            Assert.Equal(appointment, createdAtActionResult.Value);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsNoContentResult()
        {
            // Arrange
            int appointmentId = 1;
            Appointment appointment = new Appointment { Id = appointmentId, DateTime = DateTime.Now, PatientId = 1, DoctorId = 1 };
            mockAppointmentRepository.Setup(repo => repo.UpdateAsync(appointmentId, appointment)).Returns(Task.CompletedTask);

            // Act
            var result = await appointmentController.UpdateAsync(appointmentId, appointment);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
            mockAppointmentRepository.Verify(repo => repo.UpdateAsync(appointmentId, appointment), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_ReturnsNoContentResult()
        {
            // Arrange
            int appointmentId = 1;
            mockAppointmentRepository.Setup(repo => repo.DeleteAsync(appointmentId)).Returns(Task.CompletedTask);

            // Act
            var result = await appointmentController.DeleteAsync(appointmentId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
            mockAppointmentRepository.Verify(repo => repo.DeleteAsync(appointmentId), Times.Once());
        }

        [Fact]
        public async Task SearchByDateAsync_ReturnsOkResult_WithListOfAppointments()
        {
            // Arrange
            DateTime date = DateTime.Now;
            List<Appointment> appointments = new List<Appointment>
            {
                new Appointment { Id = 1, DateTime = date, PatientId = 1, DoctorId = 1 },
                new Appointment { Id = 2, DateTime = date, PatientId = 2, DoctorId = 2 },
                new Appointment { Id = 3, DateTime = date, PatientId = 3, DoctorId = 3 }
            };

            mockAppointmentRepository.Setup(repo => repo.SearchByDateAsync(date)).ReturnsAsync(appointments);

            // Act
            var result = await appointmentController.SearchByDateAsync(date);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Appointment>>(okResult.Value);
            Assert.Equal(appointments.Count, model.Count());
            mockAppointmentRepository.Verify(repo => repo.SearchByDateAsync(date), Times.Once());
        }

        [Fact]
        public async Task GetAppointmentsByDoctorIdAsync_ReturnsOkResult_WithListOfAppointments()
        {
            // Arrange
            int doctorId = 1;
            List<Appointment> appointments = new List<Appointment>
            {
                new Appointment { Id = 1, DateTime = DateTime.Now, PatientId = 1, DoctorId = doctorId },
                new Appointment { Id = 2, DateTime = DateTime.Now, PatientId = 2, DoctorId = doctorId },
                new Appointment { Id = 3, DateTime = DateTime.Now, PatientId = 3, DoctorId = doctorId }
            };

            mockAppointmentRepository.Setup(repo => repo.GetAppointmentsByDoctorIdAsync(doctorId)).ReturnsAsync(appointments);

            // Act
            var result = await appointmentController.GetAppointmentsByDoctorIdAsync(doctorId);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Appointment>>(okResult.Value);
            Assert.Equal(appointments.Count, model.Count());
            mockAppointmentRepository.Verify(repo => repo.GetAppointmentsByDoctorIdAsync(doctorId), Times.Once());
        }

        [Fact]
        public async Task GetAppointmentsByPatientIdAsync_ReturnsOkResult_WithListOfAppointments()
        {
            // Arrange
            int patientId = 1;
            List<Appointment> appointments = new List<Appointment>
            {
                new Appointment { Id = 1, DateTime = DateTime.Now, PatientId = patientId, DoctorId = 1 },
                new Appointment { Id = 2, DateTime = DateTime.Now, PatientId = patientId, DoctorId = 2 },
                new Appointment { Id = 3, DateTime = DateTime.Now, PatientId = patientId, DoctorId = 3 }
            };

            mockAppointmentRepository.Setup(repo => repo.GetAppointmentsByPatientIdAsync(patientId)).ReturnsAsync(appointments);

            // Act
            var result = await appointmentController.GetAppointmentsByPatientIdAsync(patientId);

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Appointment>>(okResult.Value);
            Assert.Equal(appointments.Count, model.Count());
            mockAppointmentRepository.Verify(repo => repo.GetAppointmentsByPatientIdAsync(patientId), Times.Once());
        }

    }
}
