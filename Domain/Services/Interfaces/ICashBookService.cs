using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.PageParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface ICashBookService : IGeneric<CashBook>
    {
        Task AddCashBook(CashBook cashbook);

        Task<List<CashBook>> GetAllCashBook(PageParameters pageParameters);

        Task<CashBook> GetCashBookByOriginId(Guid Id);

        Task<CashBook> GetCashBookById(Guid id);

        Task PutCashBook(CashBook cashbook);
    }
}