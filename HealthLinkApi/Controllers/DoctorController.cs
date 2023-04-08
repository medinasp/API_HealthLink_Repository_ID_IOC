using Domain.Interfaces.Generics;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthLinkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        private readonly IGenerics<Doctor> _doctorRepository;
        private readonly IDoctor _doctorService;

        public DoctorController(IGenerics<Doctor> doctorRepository, IDoctor doctorService)
        {
            _doctorRepository = doctorRepository;
            _doctorService = doctorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpGet("/api/GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return Ok(doctors);
        }

        [HttpPost("/api/CreateAsync")]
        public async Task<IActionResult> CreateAsync(Doctor doctor)
        {
            await _doctorRepository.CreateAsync(doctor);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Doctor doctor)
        {
            await _doctorRepository.UpdateAsync(id, doctor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _doctorRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByNameAsync([FromQuery] string name)
        {
            var doctors = await _doctorService.SearchByNameAsync(name);
            return Ok(doctors);
        }

        [HttpGet("specialty")]
        public async Task<IActionResult> GetDoctorsBySpecialtyAsync([FromQuery] string specialty)
        {
            var doctors = await _doctorService.GetDoctorsBySpecialtyAsync(specialty);
            return Ok(doctors);
        }
    }
}
