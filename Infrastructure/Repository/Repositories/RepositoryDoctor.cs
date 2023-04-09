using Entities.Entities;
using Domain.Interfaces;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Configuration;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryDoctor : RepositoryGenerics<Doctor>, IDoctor
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
