using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
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
       private readonly IDocument _idocument;
        private readonly IMapper _imapper;

        public DocumentApplication(IDocument idocument, IMapper imapper)
        {
            _idocument = idocument;
            _imapper = imapper; 
        }

        public async Task AddDocument(DocumentDTO document)
        {
            var d = new Document();
            var dm = _imapper.Map(document,d);
            await _idocument.AddDocument(dm);    
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

        public async Task UpdateDocument(DocumentDTO document)
        {
            var d = new Document();
            var dm = _imapper.Map(document, d);
            await _idocument.UpdateDocument(dm); 
        }

        public async Task UpdatePayementDocument(DocumentDTO document)
        {
            var d = new Document();
            var dm = _imapper.Map(document, d);
            await _idocument.UpdatePayementDocument(dm);
        }
    }
}
