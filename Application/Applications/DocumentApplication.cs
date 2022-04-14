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
    public class DocumentApplication : IDocumentApplication
    {
        IDocument _idocument;

        public DocumentApplication(IDocument idocument)
        {
            _idocument = idocument;
        }

        public async Task<bool> AddDocument(Document document)
        {
            return await _idocument.AddDocument(document);    
        }

        public async Task DeleteDocument(Guid id)
        {
            await _idocument.DeleteDocument(id);
        }

        public async Task<List<Document>> GetAllDocuments()
        {
           return await _idocument.GetAllDocuments();
        }

        public async Task<Document> GetById(Guid id)
        {
            return await _idocument.GetById(id);  
        }

        public async Task<bool> UpdateDocument(Document document)
        {
            return await _idocument.UpdateDocument(document); 
        }

        public async Task<bool> UpdatePayementDocument(Document document)
        {
            return await _idocument.UpdatePayementDocument(document);
        }
    }
}
