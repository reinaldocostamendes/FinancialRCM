
using Domain.Interfaces;
using Entities.Entities;
using Entities.PageParam;
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
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository

    {
        private readonly DbContextOptions<FinancialContext> dbContextOptions;

        public async Task AddDocument(Document document)
        {
          await base.Post(document); 
        }

        public async Task DeleteDocument(Guid id)
        {
            var document = await base.GetById(id);
            await base.Delete(document);
        }

        public async Task<List<Document>> GetAllDocuments(PageParameters pageParameters)
        {
           return await base.GetAll(pageParameters);  
        }

        public async Task UpdateDocument(Document document)
        {
           await base.Put(document);
        }

        public async Task UpdatePayementDocument(Document document)
        {
            document.Payed = true;
            await base.Put(document);
        }
    }
}
