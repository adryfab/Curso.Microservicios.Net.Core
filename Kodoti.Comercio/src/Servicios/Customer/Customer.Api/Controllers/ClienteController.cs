using Customer.Servicios.Queries;
using Customer.Servicios.Queries.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Servicio.Comun.Coleccion.DataColeccion;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteQueryServicio _clienteQueryServicio;

        public ClienteController (IClienteQueryServicio clienteQueryServicio)
        {
            _clienteQueryServicio = clienteQueryServicio;
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

    }
}
