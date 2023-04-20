using Domain.Interfaces;
using HealthLinkApi.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste_mock.Tests.Controllers
{
    public class PatientControllerTests
    {
        private Mock<IPatient> mockPatientRepository;
        private PatientController patientController;

        public PatientControllerTests()
        {
            mockPatientRepository = new Mock<IPatient>();
            patientController = new PatientController(mockPatientRepository.Object);
        }
    }
}
