using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using CashBook_Error.API.Contracts;
using Entities.Entities;
using Entities.PageParam;
using FIinancial_API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
                return BadRequest(new CashBookErrorMessage("600", ex.Message, cashbook));
            }
            return Ok(cashbook + "Added SuccessFull");
        }

        [HttpGet]
        public async Task<CashBookViewModel> GetAll([FromQuery] PageParameters pageParameters)
        {
            CashBookViewModel cbvm = new CashBookViewModel();
            var cbks = await _icashBookApplication.GetAllCashBook(pageParameters);
            var amount = cbks.Sum(p => p.Value);
            cbvm.Models = cbks;
            cbvm.Total = (decimal)amount;
            return cbvm;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CashBook>> GetById(Guid id)
        {
            var cashBook = await _icashBookApplication.GetCashBookById(id);
            if (cashBook == null)
            {
                return NoContent();
            }

            return Ok(cashBook);
        }

        [HttpGet("ByOrigId")]
        public async Task<ActionResult<CashBook>> GetByOrigintId(Guid OriginId)
        {
            var cashbook = await _icashBookApplication.GetCashBookOriginId(OriginId);
            if (cashbook == null) { return NoContent(); }
            return Ok(cashbook);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CashBookDTO cashbook)
        {
            try
            {
                await _icashBookApplication.PutCashBook(cashbook);
            }
            catch (Exception ex)
            {
                var result = new CashBookErrorMessage("600", $"Not possible to put CashBook: {ex.Message}", cashbook);
                return BadRequest(result);
            }
            return Ok("Upated successfull!");
        }
    }
}