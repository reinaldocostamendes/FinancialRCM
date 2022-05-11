
using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.PageParam;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICashBookRepository : IGeneric<CashBook>
    {
        Task AddCashBook(CashBook cashbook);

        Task<List<CashBook>> GetAllCashBook(PageParameters pageParameters);
        Task<CashBook> GetCashBookByOriginId(Guid Id);
        Task<CashBook> GetCashBookById(Guid id);

        Task PutCashBook(CashBook cashbook);

    }
}
