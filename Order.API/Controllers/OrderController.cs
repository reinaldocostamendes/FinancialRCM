using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderApplication _iorderApplicaction;

        public OrderController(IOrderApplication iorderApplicaction)
        {
            _iorderApplicaction = iorderApplicaction;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDTO orderDto)
        {
            try
            {
                await _iorderApplicaction.AddOrder(orderDto);
            }catch(Exception ex)
            {
               return BadRequest(ex.Message);   
            }
            return Ok("Add successfull!");    
        }
       /* [HttpGet]
        public async Task<List<Order>> GetAll()
        {
        return await _iorderApplicaction.GetAllOrders();
        }*/
    }
}
