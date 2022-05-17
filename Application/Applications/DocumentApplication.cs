using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Entities;
using Entities.PageParam;
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
        private readonly IDocumentService _idocument;
        private readonly IMapper _imapper;
        private string apiUrl;
        private HttpClient client;

        public DocumentApplication(IDocumentService idocument, IMapper imapper)
        {
            _idocument = idocument;
            _imapper = imapper;
            apiUrl = "https://localhost:44355/api/CashBooks";

            client = new HttpClient();
        }

        public async Task AddDocument(DocumentDTO document)
        {
            var d = new Document();
            var dm = _imapper.Map(document, d);
            var dmId = Guid.NewGuid();
            dm.Id = dmId;
            var odto = new CashBookDTO();
            odto.Origin = 1;
            odto.OriginId = dmId;
            odto.Description = "Document:" + dm.Number;
            if (dm.Payed == true)
            {
                dm.PaymentDate = dm.Date;
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
            var d = await _idocument.GetById(id);
            if (d == null)
            {
                throw new Exception("This Doc not exists!");
            }

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
                await _idocument.DeleteDocument(id);
            }
        }

        public async Task<List<Document>> GetAllDocuments(PageParameters pageParameters)
        {
            return await _idocument.GetAllDocuments(pageParameters);
        }

        public async Task<Document> GetById(Guid id)
        {
            return await _idocument.GetById(id);
        }

        public async Task UpdateDocument(Document document)
        {
            var d = await _idocument.GetById(document.Id);

            var odto = new CashBookDTO();
            odto.Origin = 1;
            odto.OriginId = document.Id;
            odto.Description = "Document:" + document.Number;
            if (document.Payed == true)
            {
                document.PaymentDate = DateTime.Now;
                odto.Value = document.Total - d.Total;
                odto.Type = ((document.Total - d.Total) > 0) ? 2 : 1;
            }
            else
            {
                odto.Value = document.Total - d.Total;
                odto.Type = odto.Type = ((document.Total - d.Total) > 0) ? 2 : 1;
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
            else
            {
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
            d.PaymentDate = DateTimeOffset.Now;

            var odto = new CashBookDTO();
            odto.Origin = 1;
            odto.OriginId = d.Id;
            odto.Description = "Document:" + d.Number;

            odto.Value = (pvm.Payed == true) ? -d.Total : d.Total;
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