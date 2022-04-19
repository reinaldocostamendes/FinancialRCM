using Application.DTOs;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public  interface ICashBookApplication
    {
        Task AddCashBook(CashBookDTO cashbook);

        Task<List<CashBook>> GetAllCashBook();
        Task<CashBook> GetCashBookOriginId(Guid Id);

        Task<CashBook> GetCashBookById(Guid id);

        Task PutCashBook(CashBookDTO cashbook);

    }
}
