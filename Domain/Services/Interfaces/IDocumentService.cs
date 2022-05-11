using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.PageParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IDocumentService : IGeneric<Document>
    {
        Task AddDocument(Document document);

        Task<List<Document>> GetAllDocuments(PageParameters pageParameters);

        Task<Document> GetById(Guid id);

        Task UpdateDocument(Document document);

        Task UpdatePayementDocument(Document document);

        Task DeleteDocument(Guid id);
    }
}