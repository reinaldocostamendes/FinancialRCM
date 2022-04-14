using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public  interface ICashBook
    {
        Task<bool> AddCashBook(CashBook cashbook);

        Task<List<CashBook>> GetAllCashBook();
        Task<CashBook> GetCashBookByOriginId(Guid Id);
        Task<CashBook> GetCashBookById(Guid id);

        Task<bool> PutCashBook(CashBook cashbook);

    }
}
