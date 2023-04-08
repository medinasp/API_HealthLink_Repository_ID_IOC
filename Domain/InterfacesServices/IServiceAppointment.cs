using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterfacesServices
{
    public interface IServiceAppointment
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<Appointment> GetByIdAsync(Guid id);
        Task CreateAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Guid id);
    }
}
