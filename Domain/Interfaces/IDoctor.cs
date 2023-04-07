using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces
{
    public interface IDoctor : IGenerics<Doctor>
    {
        Task<IEnumerable<Doctor>> SearchByNameAsync(string name);
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialtyAsync(string specialty);
    }
}
