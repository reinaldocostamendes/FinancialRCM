using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Infrastruture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applications
{
    public class CashBookApplication : ICashBookApplication
    {
        private readonly CashBookRepository _icashBook;
        private readonly IMapper _imapper;

        public CashBookApplication(CashBookRepository icashBook, IMapper imapper)
        {
            _icashBook = icashBook;
            _imapper = imapper; 
        }

        public async Task AddCashBook(CashBookDTO cashbook)
        {
            CashBook cb = new CashBook();
            var cbm = _imapper.Map(cashbook, cb);
             await _icashBook.AddCashBook(cbm);
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

        public async Task PutCashBook(CashBookDTO cashbook)
        {
            CashBook cb = new CashBook();
            var cbm = _imapper.Map(cashbook, cb);
            await _icashBook.PutCashBook(cbm); 
        }
    }
}
