using Entities.Entities;
using Domain.Interfaces;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryAppointment : RepositoryGenerics<Appointment>, IAppointment
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryAppointment()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(Guid patientId)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<Appointment>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(Guid doctorId)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<Appointment>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<IEnumerable<Appointment>> SearchByDateAsync(DateTime date)
        {

            return await _dbSet.Where(a => a.DateTime.Date == date.Date).ToListAsync();
        }
    }

}
