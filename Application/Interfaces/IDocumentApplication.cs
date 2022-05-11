using Application.DTOs;
using Application.ViewModel;
using Entities.Entities;
using Entities.PageParam;
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
        Task<List<Document>> GetAllDocuments(PageParameters pageParameters); 
        Task<Document> GetById(Guid id);
        Task UpdateDocument(Document document);

        Task UpdatePayementDocument(UpdatePaymentViewModel pvm);
        Task DeleteDocument(Guid id);   

    }
}
