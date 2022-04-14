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
        Task<bool> AddDocument(Document document);
        Task<List<Document>> GetAllDocuments(); 
        Task<Document> GetById(Guid id);
        Task<bool> UpdateDocument(Document document);

        Task<bool> UpdatePayementDocument(Document document);
        Task DeleteDocument(Guid id);   

    }
}
