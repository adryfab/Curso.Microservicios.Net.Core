using Catalogo.Servicios.EventHandlers.Command;
using Catalogo.Servicios.Queries;
using Catalogo.Servicios.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Servicio.Comun.Coleccion.DataColeccion;

namespace Catalogo.Api.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoQueryServicio _productoQueryServicio;
        private readonly ILogger<ProductoController> _logger;
        private readonly IMediator _mediator;

        public ProductoController(
            ILogger<ProductoController> logger,
            IProductoQueryServicio productoQueryServicio,
            IMediator mediator)
        {
            _logger = logger;
            _productoQueryServicio = productoQueryServicio;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ProductoDto>> GetAll(int pagina = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> productos = null;

            if (!string.IsNullOrEmpty(ids))
            {
                productos = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productoQueryServicio.GetAllAsync(pagina, take, productos);
        }

        [HttpGet("{id}")]
        public async Task<ProductoDto> Get(int id)
        {
            return await _productoQueryServicio.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoCrearComando comando)
        {
            await _mediator.Publish(comando);
            return Ok();
        }
    }
}
