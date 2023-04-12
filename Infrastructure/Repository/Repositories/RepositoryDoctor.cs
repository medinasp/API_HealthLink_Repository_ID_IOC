using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    public sealed class RepositoryDoctor : RepositoryGenerics<Doctor>, IDoctor
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryDoctor()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialtyAsync(string specialty)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<Doctor>().Where(d => d.Specialty == specialty).ToListAsync();
            }
        }

        public async Task<IEnumerable<Doctor>> SearchByNameAsync(string name)
        {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    return await data.Set<Doctor>().Where(d => d.Name.Contains(name)).ToListAsync();
                }
        }
    }
}
