using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Domain.Interfaces;
using Domain.Services;
using Domain.Services.Interfaces;
using Entities.Entities;
using Entities.PageParam;
using Entities.Validadors;
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
        private readonly ICashBookService _icashBook;
        private readonly IMapper _imapper;

        public CashBookApplication(ICashBookService icashBook, IMapper imapper)
        {
            _icashBook = icashBook;
            _imapper = imapper;
        }

        public async Task AddCashBook(CashBookDTO cashbook)
        {
            var validator = new CashBookValidator();
            CashBook cb = new CashBook();
            var cbm = _imapper.Map(cashbook, cb);
            var result = validator.Validate(cbm);
            if (!result.IsValid)
            {
                var message = "";
                foreach (var item in result.Errors)
                {
                    message += item.ToString() + "\n";
                }
                throw new Exception(message);
            }
            await _icashBook.AddCashBook(cbm);
        }

        public async Task<List<CashBook>> GetAllCashBook(PageParameters pageParameters)
        {
            return await _icashBook.GetAllCashBook(pageParameters);
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
            if (cashbook.Origin == 1 || cashbook.Origin == 2)
            {
                throw new Exception("Not Possible to update integrated cashbook!");
            }
            var validator = new CashBookValidator();
            CashBook cb = new CashBook();
            var cbm = _imapper.Map(cashbook, cb);
            var result = validator.Validate(cbm);
            if (!result.IsValid)
            {
                var message = "";
                foreach (var item in result.Errors)
                {
                    message += item.ToString() + "\n";
                }
                throw new Exception(message);
            }
            await _icashBook.PutCashBook(cbm);
        }
    }
}