using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthLinkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointment IAppointment;

        public AppointmentController(IAppointment IAppointment)
        {
            this.IAppointment = IAppointment;
        }

        [HttpGet("/api/[controller]/GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var appointment = await IAppointment.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpGet("/api/[controller]/GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var appointment = await IAppointment.GetAllAsync();
            return Ok(appointment);
        }

        [HttpPost("/api/[controller]/CreateAsync")]
        public async Task<IActionResult> CreateAsync(Appointment appointment)
        {
            await IAppointment.CreateAsync(appointment);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = appointment.Id }, appointment);
        }

        [HttpPut("/api/[controller]/UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(int id, Appointment appointment)
        {
            await IAppointment.UpdateAsync(id, appointment);
            return NoContent();
        }

        [HttpDelete("/api/[controller]/DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await IAppointment.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("/api/[controller]/SearchByDateAsync/{date}")]
        public async Task<IActionResult> SearchByDateAsync(DateTime date)
        {
            try
            {
                var appointments = await IAppointment.SearchByDateAsync(date);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/[controller]/GetAppointmentsByDoctorIdAsync/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            try
            {
                var appointments = await IAppointment.GetAppointmentsByDoctorIdAsync(doctorId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/[controller]/GetAppointmentsByPatientIdAsync/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatientIdAsync(int patientId)
        {
            try
            {
                var appointments = await IAppointment.GetAppointmentsByPatientIdAsync(patientId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
