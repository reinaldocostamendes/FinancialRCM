using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Document_API.API.Contacts;
using Domain.Interfaces;
using Entities.Entities;
using Entities.PageParam;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Document_API.API.Controllers
{
    [Route("api/Documents")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentApplication _idocumentApplication;
        private readonly IMapper _imapper;

        public DocumentController(IDocumentApplication idocumentApplication, IMapper imapper)
        {
            _idocumentApplication = idocumentApplication;
            _imapper = imapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DocumentDTO document)
        {
            try
            {
                await _idocumentApplication.AddDocument(document);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new DocumentErrorMessage
                    ("600", ex.Message, _imapper.Map(document, new DocumentDTO())));
            }
            return Ok("Added Successfull!");
        }

        [HttpGet]
        public async Task<List<Document>> GetAll([FromQuery] PageParameters pageParameters)
        {
            return await _idocumentApplication.GetAllDocuments(pageParameters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetById(Guid id)
        {
            var document = await _idocumentApplication.GetById(id);
            if (document == null)
            {
                return NoContent();
            }
            return Ok(document);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Document document)
        {
            try
            {
                await _idocumentApplication.UpdateDocument(document);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new DocumentErrorMessage
                    ("600", ex.Message, null));
            }
            return Ok("Updated Successfull!");
        }

        [HttpPut("SetPayment")]
        public async Task<IActionResult> PutPayment(UpdatePaymentViewModel document)
        {
            try
            {
                await _idocumentApplication.UpdatePayementDocument(document);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
            return Ok("Payed Successfull!");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _idocumentApplication.DeleteDocument(id);
            return Ok("Deleted Successfull!");
        }
    }
}