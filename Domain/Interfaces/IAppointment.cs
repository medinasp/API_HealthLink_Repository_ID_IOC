using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAppointment : IGenerics<Appointment>
    {
        Task<IEnumerable<Appointment>> SearchByDateAsync(DateTime date);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(Guid patientId);

    }
}
