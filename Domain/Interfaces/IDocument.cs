using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
   public  interface IDocument
    {
        Task<bool> AddDocument(Document document);
        Task<List<Document>> GetAllDocuments(); 
        Task<Document> GetById(Guid id);
        Task<bool> UpdateDocument(Document document);

        Task<bool> UpdatePayementDocument(Document document);
        Task DeleteDocument(Guid id);   

    }
}
