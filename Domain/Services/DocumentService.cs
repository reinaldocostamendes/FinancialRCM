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
        public async Task AddDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (!result.IsValid)
            {
               throw new Exception();
            }
            await AddDocument(document);
          
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

        public async Task UpdateDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (!result.IsValid)
            {
                throw new Exception();
            }
            await UpdateDocument(document);
           
        }
        public async Task UpdatePayementDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            if (!result.IsValid)
            {
                throw new Exception();
            }
            await UpdatePayementDocument(document);
          

        }
    }

  
    }

