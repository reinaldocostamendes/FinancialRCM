using Domain.Interfaces;
using Entities.Entities;
using Infrastruture.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Repository
{
    public class CashBookRepository 
    {
        private readonly Context _context;

        public CashBookRepository(Context context)
        {
            _context = context;
        }

        public async Task AddCashBook(CashBook cashbook)
        {
            await _context.AddAsync(cashbook);
            await _context.SaveChangesAsync();  
        }

        public async Task<List<CashBook>> GetAllCashBook()
        {
          
            return await _context.CashBook.ToListAsync();
        }

        public async Task<CashBook> GetCashBookByOriginId(Guid id)
        {
            return await _context.CashBook.FirstOrDefaultAsync(c => c.OriginId == id);
        }

        public async Task<CashBook> GetCashBookById(Guid id)
        {
            return await _context.CashBook.FirstOrDefaultAsync(c => c.Id == id);   
        }

        public async Task PutCashBook(CashBook cashbook)
        {
            _context.CashBook.Update(cashbook);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCashBook(CashBook cashbook)
        { 
          _context.CashBook.Update(cashbook);
            await _context.SaveChangesAsync();
    }
    }
}
