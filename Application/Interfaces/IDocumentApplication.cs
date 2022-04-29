using Application.DTOs;
using Application.ViewModel;
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
        Task<List<Document>> GetAllDocuments(int pageIndex, int pageSize); 
        Task<Document> GetById(Guid id);
        Task UpdateDocument(Document document);

        Task UpdatePayementDocument(UpdatePaymentViewModel pvm);
        Task DeleteDocument(Guid id);   

    }
}
