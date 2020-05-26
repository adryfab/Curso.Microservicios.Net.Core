using Customer.Persistencia.Database;
using Customer.Servicios.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Servicio.Comun.Mapping;
using Servicio.Comun.Paginando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Servicio.Comun.Coleccion.DataColeccion;

namespace Customer.Servicios.Queries
{
    public interface IClienteQueryServicio
    {
        Task<DataCollection<ClienteDto>> GetAllAsync(int pagina, int take, IEnumerable<int> clientes = null);
        Task<ClienteDto> GetAsync(int id);
    }

    public class ClienteQueryServicio : IClienteQueryServicio
    {
        private readonly AplicacionDBContext _context;

        public ClienteQueryServicio(AplicacionDBContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<ClienteDto>> GetAllAsync(int pagina, int take, IEnumerable<int> clientes = null)
        {
            var colecion = await _context.Cliente
                                .Where(x => clientes == null || clientes.Contains(x.ClienteId))
                                .OrderByDescending(x => x.ClienteId)
                                .GetPagedAsync(pagina, take);

            return colecion.MapTo<DataCollection<ClienteDto>>();
        }

        public async Task<ClienteDto> GetAsync(int id)
        {
            return (await _context.Cliente.SingleAsync(x => x.ClienteId == id)).MapTo<ClienteDto>();
        }

    }
}
