using Domain.InterfacesServices;
using Domain.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceAppointment : IServiceAppointment
    {
        private readonly IAppointment _IAppointment;

        public ServiceAppointment(IAppointment IAppointment)
        {
            _IAppointment = IAppointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            return await _IAppointment.GetAllAsync();
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _IAppointment.GetByIdAsync(id);
        }

        public async Task CreateAsync(Appointment appointment)
        {
            await _IAppointment.CreateAsync(appointment);
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            await _IAppointment.UpdateAsync(appointment);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _IAppointment.DeleteAsync(id);
        }
    }
}
