using Domain.Interfaces;
using Entities.Entities;
using Entities.Validadors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CashBookService : ICashBook
    {
        public async Task AddCashBook(CashBook cashbook)
        {
            var validator = new CashBookValidator();
            var result = validator.Validate(cashbook);
            if (result.IsValid)
            {
                throw new Exception();
            }
            await AddCashBook(cashbook);
          
        }

        public async Task<List<CashBook>> GetAllCashBook(int pageIndex, int pageSize)
        {
            return await GetAllCashBook(pageIndex,pageSize);
        }

        public async Task<CashBook> GetCashBookByOriginId(Guid id)
        {
            return await GetCashBookByOriginId(id);
        }

   

        public async Task<CashBook> GetCashBookById(Guid id)
        {
            return await GetCashBookById(id);
        }

        public async Task PutCashBook(CashBook cashbook)
        {
            var validator = new CashBookValidator();
            var result = validator.Validate(cashbook);
            if (!result.IsValid)
            {
                throw new  Exception();
            }
            await PutCashBook(cashbook);
         
        }

        public async Task<bool> UpdateCashBook(CashBook cashbook)
        {
            var validator = new CashBookValidator();
            var result = validator.Validate(cashbook);
            if (!result.IsValid)
            {
                return false;
            }
            await UpdateCashBook(cashbook);
            return true;
        }
    }
}
