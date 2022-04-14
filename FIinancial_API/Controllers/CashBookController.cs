using Application.Interfaces;
using AutoMapper;
using Entities.Entities;
using FIinancial_API.DTOs;
using FIinancial_API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FIinancial_API.Controllers
{
    [Route("api/CashBooks")]
    [ApiController]
    public class CashBookController : ControllerBase
    {
        private readonly ICashBookApplication _icashBookApplication;
        private readonly IMapper _imapper;

        public CashBookController(ICashBookApplication icashBookApplication, IMapper imapper)
        {
            _icashBookApplication = icashBookApplication;
            _imapper = imapper; 
        }
         [HttpPost]
         public async Task<IActionResult> Post([FromBody] CashBookDTO cashbook)
         {
            CashBook cb = new CashBook();
         var cbm =   _imapper.Map(cashbook,cb);
          var result=  await _icashBookApplication.AddCashBook(cbm);
            return Ok(result);
         }
    }
}
