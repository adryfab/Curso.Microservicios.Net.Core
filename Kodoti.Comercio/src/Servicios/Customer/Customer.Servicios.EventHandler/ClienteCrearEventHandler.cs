using Customer.Dominio;
using Customer.Persistencia.Database;
using Customer.Servicios.EventHandler.Comando;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Servicios.EventHandler
{
    public class ClienteCrearEventHandler : INotificationHandler<ClienteCrearComando>
    {
        private readonly AplicacionDBContext _context;

        public ClienteCrearEventHandler (AplicacionDBContext context)
        {
            _context = context;
        }

        public async Task Handle(ClienteCrearComando comando, CancellationToken cancellation)
        {
            await _context.AddAsync(new Cliente
            {
                Nombre = comando.Nombre
            });

            await _context.SaveChangesAsync();
        }

    }
}
