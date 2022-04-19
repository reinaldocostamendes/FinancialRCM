using Application.DTOs;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
   public  interface IDocumentApplication
    {
        Task AddDocument(DocumentDTO document);
        Task<List<Document>> GetAllDocuments(); 
        Task<Document> GetById(Guid id);
        Task UpdateDocument(DocumentDTO document);

        Task UpdatePayementDocument(DocumentDTO document);
        Task DeleteDocument(Guid id);   

    }
}
