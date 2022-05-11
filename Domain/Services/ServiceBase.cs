using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.PageParam;

namespace Domain.Services
{
    public class ServiceBase<T> where T : class
    {
        public Task Post(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Put(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll(PageParameters pageParameters)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}