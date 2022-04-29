using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Entities.Entities;
using FIinancial_API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FIinancial_API.Controllers
{
    [Route("api/CashBooks")]
    [ApiController]
    public class CashBookController : ControllerBase
    {
        private readonly ICashBookApplication _icashBookApplication;


        public CashBookController(ICashBookApplication icashBookApplication)
        {
            _icashBookApplication = icashBookApplication;
     
        }
         [HttpPost]
         public async Task<IActionResult> Post([FromBody] CashBookDTO cashbook)
         {
            try
            {
                await _icashBookApplication.AddCashBook(cashbook);
            }
             
            catch (Exception ex)
            {
                return BadRequest(ex.Message+" Not Possible to put CashBook");
            }
            return Ok();
         }
        [HttpGet]
        public async Task<CashBookViewModel> GetAll(int pageIndex, int pageSize)
        {
            CashBookViewModel cbvm = new CashBookViewModel();
            var cbks =  await _icashBookApplication.GetAllCashBook(pageIndex,pageSize);
            var amount = 0.0;
            foreach (var cashbook in cbks)
            {
                amount += (double)cashbook.Value;
            }
           
            cbvm.Models = cbks;
            cbvm.Total = (decimal)amount;
            return  cbvm; 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CashBook>> GetById(Guid id)
        {
            var cashBook = await _icashBookApplication.GetCashBookById(id);
            if(cashBook == null)
            {
                return  NoContent();
            }    
                
            return Ok(cashBook);
        }

        [HttpGet("{documentId}")]
        public async Task<ActionResult<CashBook>> GetByOrigintId(Guid documentId)
        {
            var cashbook = await _icashBookApplication.GetCashBookOriginId(documentId);
            if(cashbook == null) { return NoContent(); }    
            return Ok(cashbook);    
        }
        [HttpPut]
        public async Task<IActionResult> Put(CashBookDTO cashbook)
        {
            try
            {
                if(cashbook.Origin !=1 && cashbook.Origin != 2)
                {
                    await _icashBookApplication.PutCashBook(cashbook);
                }
                else
                {
                    return BadRequest("Not Possible to change integrated cashbook!");
                }              
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok("Upated successfull!");
        }
    }
}
