using Application.DTOs;
using Application.ViewModel;
using Entities.Entities;
using Entities.PageParam;
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

        Task<List<CashBook>> GetAllCashBook(PageParameters pageParameters);
        Task<CashBook> GetCashBookOriginId(Guid Id);

        Task<CashBook> GetCashBookById(Guid id);

        Task PutCashBook(CashBookDTO cashbook);

    }
}
