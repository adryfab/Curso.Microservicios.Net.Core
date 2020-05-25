using Catalogo.Dominio;
using Catalogo.Servicios.EventHandlers.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Api.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class ProductoEnStockController : ControllerBase
    {
        private readonly ILogger<ProductoEnStockController> _logger;
        private readonly IMediator _mediator;

        public ProductoEnStockController(
            ILogger<ProductoEnStockController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductoEnStockActualizarComnando command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}
