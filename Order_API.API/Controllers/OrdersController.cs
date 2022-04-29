using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Entities.Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Order_API.API.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderApplication _iorderApplication;
        private readonly IOrderProductApplication _iorderProductApplication;
        private readonly IMapper _imapper;


        public OrdersController(IOrderApplication iorderApplication, IOrderProductApplication iorderProductApplication, IMapper imapper)
        {
            _iorderApplication = iorderApplication;
            _iorderProductApplication = iorderProductApplication;
            _imapper = imapper; 
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDTO order)
        {
            try
            {
              await  _iorderApplication.AddOrder(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message+": Error");
            }
            return Ok("Added Successfull!");
        }
        [HttpGet]
        public async Task<List<OrderViewModel>> GetAll(int pageIndex,int pageSize)
        {
            List<OrderViewModel> ovms = new List<OrderViewModel>(); 
            var orders = await _iorderApplication.GetAllOrders(pageIndex,pageSize);
            foreach (var order in orders)
            {
              var ops = await _iorderProductApplication.GetAllOrderProductsByOrderId(order.Id);
                OrderViewModel ov = new OrderViewModel();
                var ovm = _imapper.Map(order, ov);
                ovm.OrderProducts = ops;
                ovms.Add(ovm);
            }
            return ovms; 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> GetByClient(Guid id)
        {
            var o = await _iorderApplication.GetOrdersByClient(id);
            var ops = await _iorderProductApplication.GetAllOrderProductsByOrderId(o.Id);
            OrderViewModel ov = new OrderViewModel();
            var ovm = _imapper.Map(o, ov);
            ovm.OrderProducts = ops;
            if (ovm == null)
            {
                return NoContent();
            }
            return Ok(ovm); 
        }
        [HttpPut]
        public async Task<IActionResult> Put(OrderViewModel order)
        {
            try
            {
                if (order.Status == OrderStatus.FINISHED)
                {
                    return Ok("Not Possible to change Fnished Order!");
                }
                else
                {
                    await _iorderApplication.UpdateOrder(order);
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }
        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] OrderStatusViewModel osvm) 
        {
            try
            {
            await _iorderApplication.UpdateOrderStatus(osvm.Id,osvm.Status);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Status Changed successfull!");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _iorderApplication.DeleteOrder(id); 
            return Ok();    
        }
    }
}
