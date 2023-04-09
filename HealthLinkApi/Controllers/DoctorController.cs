using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthLinkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private readonly IDoctor IDoctor;

        public DoctorController(IDoctor IDoctor)
        {
            this.IDoctor = IDoctor;
        }

        [HttpGet("/api/[controller]/GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var doctor = await IDoctor.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpGet("/api/[controller]/GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var doctors = await IDoctor.GetAllAsync();
            return Ok(doctors);
        }

        [HttpPost("/api/[controller]/CreateAsync")]
        public async Task<IActionResult> CreateAsync(Doctor doctor)
        {
            await IDoctor.CreateAsync(doctor);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = doctor.Id }, doctor);
        }

        [HttpPut("/api/[controller]/UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(int id, Doctor doctor)
        {
            await IDoctor.UpdateAsync(id, doctor);
            return NoContent();
        }

        [HttpDelete("/api/[controller]/DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await IDoctor.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("/api/[controller]/SearchByNameAsync")]
        public async Task<IActionResult> SearchByNameAsync([FromQuery] string name)
        {
            var doctors = await IDoctor.SearchByNameAsync(name);
            return Ok(doctors);
        }

        [HttpGet("/api/[controller]/GetDoctorsBySpecialtyAsync")]
        public async Task<IActionResult> GetDoctorsBySpecialtyAsync([FromQuery] string specialty)
        {
            var doctors = await IDoctor.GetDoctorsBySpecialtyAsync(specialty);
            return Ok(doctors);
        }
    }
}
