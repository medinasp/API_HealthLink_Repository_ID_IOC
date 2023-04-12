using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public sealed class RepositoryAppointment : RepositoryGenerics<Appointment>, IAppointment
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryAppointment()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<Appointment>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<Appointment>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<IEnumerable<Appointment>> SearchByDateAsync(DateTime date)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<Appointment>().Where(a => a.DateTime.Date == date.Date).ToListAsync();
            }
        }
    }

}
