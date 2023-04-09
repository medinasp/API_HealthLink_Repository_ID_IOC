using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces
{
    public interface IPatient : IGenerics<Patient>
    {
        Task<IEnumerable<Patient>> SearchByNameAsync(string name);
        Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(int doctorId);
    }
}
