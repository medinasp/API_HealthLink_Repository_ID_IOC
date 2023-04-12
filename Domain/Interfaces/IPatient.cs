using Domain.Interfaces.Generics;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPatient : IGenerics<Patient>
    {
        Task<IEnumerable<Patient>> SearchByNameAsync(string name);
        Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(int doctorId);
    }
}
