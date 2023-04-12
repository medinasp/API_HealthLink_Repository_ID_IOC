using Domain.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthLinkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatient IPatient;

        public PatientController(IPatient IPatient)
        {
            this.IPatient = IPatient;
        }

        [HttpGet("/api/[controller]/GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var patient = await IPatient.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpGet("/api/[controller]/GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var patients = await IPatient.GetAllAsync();
            return Ok(patients);
        }

        [HttpPost("/api/[controller]/CreateAsync")]
        public async Task<IActionResult> CreateAsync(Patient patient)
        {
            await IPatient.CreateAsync(patient);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = patient.Id }, patient);
        }

        [HttpPut("/api/[controller]/UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(int id, Patient patient)
        {
            await IPatient.UpdateAsync(id, patient);
            return NoContent();
        }

        [HttpDelete("/api/[controller]/DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await IPatient.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("/api/[controller]/SearchByNameAsync")]
        public async Task<IActionResult> SearchByNameAsync([FromQuery] string name)
        {
            var patients = await IPatient.SearchByNameAsync(name);
            return Ok(patients);
        }

        [HttpGet("/api/[controller]/GetPatientsByDoctorIdAsync")]
        public async Task<IActionResult> GetPatientsByDoctorIdAsync([FromQuery] int doctorId)
        {
            var patients = await IPatient.GetPatientsByDoctorIdAsync(doctorId);
            return Ok(patients);
        }

    }
}
