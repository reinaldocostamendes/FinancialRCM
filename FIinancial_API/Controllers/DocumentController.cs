using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIinancial_API.Controllers
{
    [Route("api/Documents")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private IDocumentApplication idocumentApplication;
        private readonly IMapper _imapper;

        public DocumentController(IDocumentApplication idocumentApplication, IMapper imapper)
        {
            this.idocumentApplication = idocumentApplication;
            this._imapper = imapper;    
        }
    }
}
