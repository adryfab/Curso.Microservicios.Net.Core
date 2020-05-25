using Catalogo.Dominio;
using Catalogo.Pruebas.Config;
using Catalogo.Servicios.EventHandlers;
using Catalogo.Servicios.EventHandlers.Command;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading;
using static Catalogo.Comun.Enums;

namespace Catalogo.Pruebas
{
    [TestClass]
    public class ProductoEnStockActualizarEventHandlerTest
    {
        private ILogger<ProductoEnStockActualizarEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductoEnStockActualizarEventHandler>>()
                    .Object;
            }
        }

        [TestMethod]
        public void IntentarSustraerStockCuandoProductoTieneStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            //var productoEnStockId = 1;
            var productoId = 1;
            var stock = 1;

            context.Stocks.Add(new ProductoEnStock
            {
                ProductoEnStockId = 1,
                ProductoId = productoId,
                Stock = stock
            });

            context.SaveChanges();

            var handler = new ProductoEnStockActualizarEventHandler(context, GetLogger);

            handler.Handle(new ProductoEnStockActualizarComnando { 
                Items = new List<ProductoEnStockActualizarItem>() { 
                    new ProductoEnStockActualizarItem {
                        ProductoId = productoId,
                        Stock = stock,
                        Accion = ProductoEnStockAccion.Substract
                    }
                }
            }, new CancellationToken()).Wait();
        }
    }
}
