using Entities.Entities;
using Domain.Interfaces;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Configuration;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryPatient : RepositoryGenerics<Patient>, IPatient
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        private readonly IAppointment _appointmentRepository;

        public RepositoryPatient(IAppointment appointmentRepository)
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(Guid doctorId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDoctorIdAsync(doctorId);
            var patientIds = appointments.Select(a => a.PatientId).Distinct();
            return await _dbSet.Where(p => patientIds.Contains(p.Id)).ToListAsync();
        }

        public async Task<IEnumerable<Patient>> SearchByNameAsync(string name)
        {
            return await _dbSet.Where(p => p.Name.Contains(name)).ToListAsync();
        }
    }

}
