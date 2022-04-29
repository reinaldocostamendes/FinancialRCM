using Domain.Interfaces.Generics;
using Infrastruture.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Repository.Generics
{
    public class GenericRepository<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<FinancialContext> _optionsBuilder;
        public GenericRepository()
        {
            _optionsBuilder = new DbContextOptions<FinancialContext>();
        }

        public async Task Delete(T entity)
        {
            using (var data = new FinancialContext(_optionsBuilder))
            {
               data.Set<T>().Remove(entity);
               
                await data.SaveChangesAsync();
            }
        }

      

        public async Task<List<T>> GetAll(int pageIndex,int pageSize)
        {
            using (var data = new FinancialContext(_optionsBuilder))
            {
                var items = await data.Set<T>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                return items;
            }
        }

        public async Task<T> GetById(Guid id)
        {
              using( var data = new FinancialContext(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task Post(T entity)
        {
             using( var data = new FinancialContext(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(entity);   
                await data.SaveChangesAsync();  
            }
        }

        public async Task Put(T entity)
        {
            using (var data = new FinancialContext(_optionsBuilder))
            {
                 data.Set<T>().Update(entity);
                await data.SaveChangesAsync();
            }
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
