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
    public class DocumentService : ServiceBase<Document>, IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task AddDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (!result.IsValid)
            {
                throw new Exception();
            }
            await _documentRepository.AddDocument(document);
        }

        public Task Delete(Document entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDocument(Guid id)
        {
            await _documentRepository.DeleteDocument(id);
        }

        public Task<List<Document>> GetAll(PageParameters pageParameters)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Document>> GetAllDocuments(PageParameters pageParameters)
        {
            return await _documentRepository.GetAllDocuments(pageParameters);
        }

        public async Task<Document> GetById(Guid id)
        {
            return await _documentRepository.GetById(id);
        }

        public async Task UpdateDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (!result.IsValid)
            {
                throw new Exception();
            }
            await _documentRepository.UpdateDocument(document);
        }

        public async Task UpdatePayementDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (!result.IsValid)
            {
                throw new Exception();
            }
            await _documentRepository.UpdatePayementDocument(document);
        }
    }
}