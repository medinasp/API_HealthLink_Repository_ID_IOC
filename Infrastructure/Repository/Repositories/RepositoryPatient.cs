using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryPatient : RepositoryGenerics<Patient>, IPatient
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        private readonly IAppointment IAppointment;

        public RepositoryPatient(IAppointment IAppointment)
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
            IAppointment = IAppointment;
        }

        public async Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(int doctorId)
        {
            var appointments = await IAppointment.GetAppointmentsByDoctorIdAsync(doctorId);
            var patientIds = appointments.Select(a => a.PatientId).Distinct();

            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<Patient>().Where(p => patientIds.Contains(p.Id)).ToListAsync();
            }
        }

        public async Task<IEnumerable<Patient>> SearchByNameAsync(string name)
        {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    return await data.Set<Patient>().Where(p => p.Name.Contains(name)).ToListAsync();
                }
        }
    }

}
