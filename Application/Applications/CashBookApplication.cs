using Application.Interfaces;
using Domain.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applications
{
    public class CashBookApplication : ICashBookApplication
    {
        ICashBook _icashBook;

        public CashBookApplication(ICashBook icashBook)
        {
            _icashBook = icashBook;
        }

        public async Task<bool> AddCashBook(CashBook cashbook)
        {
           return  await _icashBook.AddCashBook(cashbook);
        }

        public async Task<List<CashBook>> GetAllCashBook()
        {
            return await _icashBook.GetAllCashBook();
        }

        public async Task<CashBook> GetCashBookOriginId(Guid Id)
        {
            return await _icashBook.GetCashBookByOriginId(Id);
        }

        public Task<CashBook> GetCashBookById(Guid id)
        {
            return _icashBook.GetCashBookById(id);  
        }

        public async Task<bool> PutCashBook(CashBook cashbook)
        {
           return await _icashBook.PutCashBook(cashbook); 
        }
    }
}
