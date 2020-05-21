using Catalogo.Dominio;
using Catalogo.Persistencia.Database;
using Catalogo.Servicios.EventHandlers.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalogo.Servicios.EventHandlers
{
    public class ProductoCrearEventHandler : INotificationHandler<ProductoCrearComando>
    {
        private readonly AplicacionDBContext _context;

        public ProductoCrearEventHandler(AplicacionDBContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductoCrearComando comando, CancellationToken cancellation)
        {
            await _context.AddAsync(new Producto
            {
                Nombre = comando.Nombre,
                Descripcion = comando.Descripcion,
                Precio = comando.Precio
            });

            await _context.SaveChangesAsync();
        }
    }
}
