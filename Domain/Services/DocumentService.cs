using Domain.Interfaces;
using Entities.Entities;
using Entities.Validadors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DocumentService : IDocument
    {
        public async Task<bool> AddDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (!result.IsValid)
            {
                return false;
            }
            await AddDocument(document);
            return true;
        }

        public async Task DeleteDocument(Guid id)
        {
            await DeleteDocument(id);
        }

        public async Task<List<Document>> GetAllDocuments()
        {
            return await GetAllDocuments();
        }

        public async Task<Document> GetById(Guid id)
        {
            return await GetById(id);
        }

        public async Task<bool> UpdateDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (!result.IsValid)
            {
                return false;
            }
            await UpdateDocument(document);
            return true;
        }
        public async Task<bool> UpdatePayementDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (!result.IsValid)
            {
                return false;
            }
            await UpdatePayementDocument(document);
            return true;

        }
    }

  
    }

