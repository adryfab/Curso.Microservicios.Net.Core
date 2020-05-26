using Customer.Servicios.EventHandler.Comando;
using Customer.Servicios.Queries;
using Customer.Servicios.Queries.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Servicio.Comun.Coleccion.DataColeccion;
using MediatR;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteQueryServicio _clienteQueryServicio;
        private readonly IMediator _mediator;

        public ClienteController (IClienteQueryServicio clienteQueryServicio,
            IMediator mediator)
        {
            _clienteQueryServicio = clienteQueryServicio;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ClienteDto>> GetAll(int pagina = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> clientes = null;

            if (!string.IsNullOrEmpty(ids))
            {
                clientes = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _clienteQueryServicio.GetAllAsync(pagina, take, clientes);
        }

        [HttpGet("{id}")]
        public async Task<ClienteDto> Get(int id)
        {
            return await _clienteQueryServicio.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteCrearComando comando)
        {
            await _mediator.Publish(comando);
            return Ok();
        }

    }
}
