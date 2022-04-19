using Application.DTOs;
using Application.Interfaces;
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
         catch(Exception ex)
            {
                    return BadRequest(ex.Message);
            }
            return Ok();
         }
        [HttpGet]
        public async Task<List<CashBook>> GetAll()
        {
            return await _icashBookApplication.GetAllCashBook();    
        }
        [HttpGet("{id}")]
        public async Task<CashBook> GetById(Guid id)
        {
            return await _icashBookApplication.GetCashBookById(id);
        }

        [HttpGet("{documentId}")]
        public async Task<CashBook> GetByOrigintId(Guid documentId)
        {
            return await _icashBookApplication.GetCashBookOriginId(documentId);
        }
        [HttpPut]
        public async Task<IActionResult> Put(CashBookDTO cashbook)
        {
            try
            {
             await   _icashBookApplication.PutCashBook(cashbook);    
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok("Upated successfull!");
        }
    }
}
