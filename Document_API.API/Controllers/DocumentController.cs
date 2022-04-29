using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Document_API.API.Controllers
{
    [Route("api/Documents")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentApplication _idocumentApplication;

        public DocumentController(IDocumentApplication idocumentApplication)
        {
            _idocumentApplication = idocumentApplication;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DocumentDTO document)
        {
            try
            {
                await _idocumentApplication.AddDocument(document);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Added Successfull!");
        }

        [HttpGet]
        public async Task<List<Document>> GetAll(int pageIndex,int pageSize)
        {
            return await _idocumentApplication.GetAllDocuments(pageIndex,pageSize);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetById(Guid id)
        {
            var document = await _idocumentApplication.GetById(id); 
            if(document == null)
            {
                return NoContent();
            }
            return  Ok(document);
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
                return BadRequest(ex.Message);
            }
            return Ok("Added Successfull!");
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
                return BadRequest(ex.Message);
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
