using Domain.Interfaces.Generics;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HealthLinkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        //private readonly IGenerics<Doctor> _doctorRepository;
        private readonly IDoctor IDoctor;

        public DoctorController(IDoctor IDoctor)
        {
            this.IDoctor = IDoctor;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var doctor = await IDoctor.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpGet("/api/GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var doctors = await IDoctor.GetAllAsync();
            return Ok(doctors);
        }

        [HttpPost("/api/CreateAsync")]
        public async Task<IActionResult> CreateAsync(Doctor doctor)
        {
            await IDoctor.CreateAsync(doctor);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Doctor doctor)
        {
            await IDoctor.UpdateAsync(id, doctor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await IDoctor.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByNameAsync([FromQuery] string name)
        {
            var doctors = await IDoctor.SearchByNameAsync(name);
            return Ok(doctors);
        }

        [HttpGet("specialty")]
        public async Task<IActionResult> GetDoctorsBySpecialtyAsync([FromQuery] string specialty)
        {
            var doctors = await IDoctor.GetDoctorsBySpecialtyAsync(specialty);
            return Ok(doctors);
        }
    }
}
