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
    public class DocumentRepository
         
    {
        private readonly Context _context;

        public DocumentRepository(Context context)
        {
            _context = context;
        }

        public async Task AddDocument(Document document)
        {
            await _context.AddAsync(document);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocument(Guid id)
        {
            var DocumentToDelete = await  _context.Document.FindAsync(id);
            _context.Document.Remove(DocumentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Document>> GetAllDocuments()
        {
            return await _context.Document.ToListAsync();
        }

        public async Task<Document> GetById(Guid id)
        {
           return await _context.Document.FindAsync(id);
        }

        public async Task UpdateDocument(Document document)
        {
            _context.Document.Update(document);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePayementDocument(Document document)
        {
            document.Payed=true;
            document.PaymentDate=DateTime.Now;
            _context.Document.Update(document);
            await _context.SaveChangesAsync();
        }
    }
}
