using Catalogo.Dominio;
using Catalogo.Persistencia.Database;
using Catalogo.Servicios.EventHandlers.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Catalogo.Comun.Enums;

namespace Catalogo.Servicios.EventHandlers
{
    public class ProductoEnStockActualizarEventHandler : INotificationHandler<ProductoEnStockActualizarComnando>
    {
        private readonly AplicacionDBContext _context;
        private readonly ILogger<ProductoEnStockActualizarEventHandler> _logger;

        public ProductoEnStockActualizarEventHandler(AplicacionDBContext context,
            ILogger<ProductoEnStockActualizarEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(ProductoEnStockActualizarComnando comando, CancellationToken cancellation)
        {
            _logger.LogInformation("--- ProductoEnStockActualizarComnando inicia");

            var productos = comando.Items.Select(x => x.ProductoId);
            var stocks = await _context.Stocks.Where(x => productos.Contains(x.ProductoId)).ToListAsync();

            _logger.LogInformation("--- Obtuvo los productos de la base de datos");

            foreach (var item in comando.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductoId == item.ProductoId);

                if (item.Accion == ProductoEnStockAccion.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($"--- Producto {entry.ProductoId} no tiene suficiente stock");
                        throw new Exception($"Producto {entry.ProductoId} no tiene suficiente stock");
                    }

                    entry.Stock -= item.Stock;
                    _logger.LogInformation($"--- El producto {entry.ProductoId} fue sustraido. Ahora tiene {entry.Stock}");
                }
                else //Add
                {
                    if (entry == null)
                    {
                        entry = new ProductoEnStock
                        {
                            ProductoId = item.ProductoId
                        };

                        await _context.AddAsync(entry);
                        _logger.LogInformation($"--- Nuevo stock fue creado del producto {entry.ProductoId}");
                    }

                    entry.Stock += item.Stock;
                    _logger.LogInformation($"--- Al producto {entry.ProductoId} se le añadió el stock {entry.Stock}");
                }
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation("--- ProductoEnStockActualizarComnando finaliza");
        }
    }
}
