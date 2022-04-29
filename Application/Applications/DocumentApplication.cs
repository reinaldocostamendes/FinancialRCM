using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Entities.Validadors;
using Infrastruture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applications
{
    public class DocumentApplication : IDocumentApplication
    {
       private readonly DocumentRepository _idocument;
        private readonly IMapper _imapper;

        public DocumentApplication(DocumentRepository idocument, IMapper imapper)
        {
            _idocument = idocument;
            _imapper = imapper; 
        }

        public async Task AddDocument(DocumentDTO document)
        {
           
            string apiUrl = "https://localhost:44323/api/CashBooks";

            var client = new HttpClient();
            var d = new Document();
            var dm = _imapper.Map(document,d);
            var dmId = Guid.NewGuid();
            dm.Id=dmId;
            var odto = new CashBookDTO();
            odto.Origin = 1;
            odto.OriginId = dmId;
            odto.Description = "Document:" + dm.Number;
            if (dm.Payed == true)
            {
                dm.PaymentDate= dm.Date;   
                odto.Value = dm.Total;
                odto.Type = 2;
            }
            else
            {
                odto.Value = -dm.Total;
                odto.Type = 1;
            }
            var validator = new DocumentValidator();
            var result = validator.Validate(dm);
            if (!result.IsValid)
            {
                var message = "";
                foreach (var item in result.Errors)
                {
                    message += item.ToString() + "\n";
                }
                throw new Exception(message);
            }
            // var jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(odto);

            var response = await client.PostAsJsonAsync(apiUrl, odto);
            if (response != null && !response.IsSuccessStatusCode)
            {
                // var result = JsonSerializer.Deserialize<string>(response.Content.)
                throw new Exception("Error to put cashbook! " + response.ToString());
            }
            else
            {
                await _idocument.AddDocument(dm);
            }
               
        }

        public async Task DeleteDocument(Guid id)
        {
            await _idocument.DeleteDocument(id);

            var d = await _idocument.GetById(id);

            string apiUrl = "https://localhost:44323/api/CashBooks";

            var client = new HttpClient();

            var odto = new CashBookDTO();
            odto.Origin = 1;
            odto.OriginId = d.Id;
            odto.Description = "Document:" + d.Number;

            odto.Value = d.Total;
            odto.Type = 3;

            // var jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(odto);

            var response = await client.PostAsJsonAsync(apiUrl, odto);
            if (response != null && !response.IsSuccessStatusCode)
            {
                // var result = JsonSerializer.Deserialize<string>(response.Content.)
                throw new Exception("Error to put cashbook! " + response.ToString());
            }
            else
            {
                await _idocument.UpdatePayementDocument(d);
            }
        }

        public async Task<List<Document>> GetAllDocuments(int pageIndex, int pageSize)
        {
           return await _idocument.GetAllDocuments(pageIndex,pageSize);
        }

        public async Task<Document> GetById(Guid id)
        {
            return await _idocument.GetById(id);  
        }

        public async Task UpdateDocument(Document document)
        {
            string apiUrl = "https://localhost:44323/api/CashBooks";

            var client = new HttpClient();
            var d = await _idocument.GetById(document.Id);
          
          
           
            var odto = new CashBookDTO();
            odto.Origin = 1;
            odto.OriginId = document.Id;
            odto.Description = "Document:" + document.Number;
            if (document.Payed == true)
            {
                document.PaymentDate = DateTime.Now;
                odto.Value = document.Total-d.Total;
                odto.Type = 2;
            }
            else
            {
                odto.Value = -document.Total-d.Total;
                odto.Type = 1;
            }

            var validator = new DocumentValidator();
            var result = validator.Validate(d);
            if (!result.IsValid)
            {
                var message = "";
                foreach (var item in result.Errors)
                {
                    message += item.ToString() + "\n";
                }
                throw new Exception(message);
            }
            else { 
            // var jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(odto);

            var response = await client.PostAsJsonAsync(apiUrl, odto);
            if (response != null && !response.IsSuccessStatusCode)
            {
                // var result = JsonSerializer.Deserialize<string>(response.Content.)
                throw new Exception("Error to put cashbook! " + response.ToString());
            }
            else
            {
                await _idocument.UpdateDocument(document);
            }
            }

        }

        public async Task UpdatePayementDocument(UpdatePaymentViewModel pvm)
        {
            var d = await _idocument.GetById(pvm.Id);
            d.Payed = pvm.Payed;    
            d.PaymentDate=DateTimeOffset.Now;
   

            string apiUrl = "https://localhost:44323/api/CashBooks";

            var client = new HttpClient();
           
            var odto = new CashBookDTO();
            odto.Origin = 1;
            odto.OriginId = d.Id;
            odto.Description = "Document:" + d.Number;
        
                odto.Value =(pvm.Payed==true) ? d.Total:-d.Total;
                odto.Type = (pvm.Payed == true) ? 1 : 2;         

            // var jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(odto);

            var response = await client.PostAsJsonAsync(apiUrl, odto);
            if (response != null && !response.IsSuccessStatusCode)
            {
                // var result = JsonSerializer.Deserialize<string>(response.Content.)
                throw new Exception("Error to put cashbook! " + response.ToString());
            }
            else
            {
                await _idocument.UpdatePayementDocument(d);
            }
        }
    }
}
