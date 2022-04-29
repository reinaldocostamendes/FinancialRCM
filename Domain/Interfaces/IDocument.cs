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
        Task AddDocument(Document document);
        Task<List<Document>> GetAllDocuments(int pageIndex, int pageSize); 
        Task<Document> GetById(Guid id);
        Task UpdateDocument(Document document);

        Task UpdatePayementDocument(Document document);
        Task DeleteDocument(Guid id);   

    }
}
