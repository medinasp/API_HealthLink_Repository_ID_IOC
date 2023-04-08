﻿using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using Infrastructure.Configuration;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryGenerics<TEntity> : IGenerics<TEntity>, IDisposable where TEntity : class
    {
        protected readonly DbContextOptions<ContextBase> _OptionsBuilder;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                await data.AddAsync(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                var entity = await GetByIdAsync(id);
                data.Remove(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                _dbSet.Update(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        #endregion

    }

}
