
using Entities.PageParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IGeneric<T> where T : class
    {
        Task Post(T entity);
        Task Put(T entity);

        Task Delete(T entity);
        Task<List<T>> GetAll(PageParameters pageParameters);
        Task<T> GetById(Guid id);
    }
}
