using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIinancial_API.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderApplication iorderApplication;
        private readonly IMapper _imapper;

        public OrderController(IOrderApplication iorderApplication, IMapper imapper)
        {
            this.iorderApplication = iorderApplication;
            this._imapper = imapper;
        }
    }
}
