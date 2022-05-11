using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Entities;
using Entities.PageParam;
using Entities.Validadors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CashBookService : ServiceBase<CashBook>, ICashBookService
    {
        private readonly ICashBookRepository _cashBookRepository;

        public CashBookService(ICashBookRepository cashBookRepository)
        {
            _cashBookRepository = cashBookRepository;
        }

        public async Task AddCashBook(CashBook cashbook)
        {
            var validator = new CashBookValidator();
            var result = validator.Validate(cashbook);
            if (!result.IsValid)
            {
                throw new Exception();
            }
            await _cashBookRepository.AddCashBook(cashbook);
        }

        public async Task<List<CashBook>> GetAllCashBook(PageParameters pageParameters)
        {
            return await _cashBookRepository.GetAllCashBook(pageParameters);
        }

        public async Task<CashBook> GetCashBookByOriginId(Guid id)
        {
            return await _cashBookRepository.GetCashBookByOriginId(id);
        }

        public async Task<CashBook> GetCashBookById(Guid id)
        {
            return await _cashBookRepository.GetCashBookById(id);
        }

        public async Task PutCashBook(CashBook cashbook)
        {
            var validator = new CashBookValidator();
            var result = validator.Validate(cashbook);
            if (!result.IsValid)
            {
                throw new Exception();
            }
            await _cashBookRepository.PutCashBook(cashbook);
        }
    }
}