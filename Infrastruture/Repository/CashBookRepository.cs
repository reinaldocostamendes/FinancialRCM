using Domain.Interfaces;
using Entities.Entities;
using Infrastruture.Configurations;
using Infrastruture.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Repository
{
    public class CashBookRepository : GenericRepository<CashBook>, ICashBook
    {
        private readonly DbContextOptions<FinancialContext> dbContextOptions;

        public CashBookRepository(DbContextOptions<FinancialContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public async Task AddCashBook(CashBook cashbook)
        {
           await base.Post(cashbook); 
        }

        public async Task<List<CashBook>> GetAllCashBook(int pageIndex, int pageSize)
        {
            return await base.GetAll(pageIndex,pageSize);
        }

        public async Task<CashBook> GetCashBookById(Guid id)
        {
            return await base.GetById(id);
        }

        public async Task<CashBook> GetCashBookByOriginId(Guid Id)
        {
            using (var data = new FinancialContext(dbContextOptions))
            {
                return await data.Set<CashBook>().FirstOrDefaultAsync(c =>c.OriginId==Id);
            }
        }

        public async Task PutCashBook(CashBook cashbook)
        {
           await base.Put(cashbook);
        }
    }
}
