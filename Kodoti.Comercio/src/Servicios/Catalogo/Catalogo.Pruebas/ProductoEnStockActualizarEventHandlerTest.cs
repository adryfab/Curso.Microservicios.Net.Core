using Catalogo.Dominio;
using Catalogo.Pruebas.Config;
using Catalogo.Servicios.EventHandlers;
using Catalogo.Servicios.EventHandlers.Command;
using Catalogo.Servicios.EventHandlers.Excepciones;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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

        [TestMethod]
        [ExpectedException(typeof(ProductoEnStockActualizarComnandoExcepcion))]
        public void IntentarSustraerStockCuandoProductoNoTieneStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productoId = 2;
            var stock = 1;

            context.Stocks.Add(new ProductoEnStock
            {
                ProductoEnStockId = 2,
                ProductoId = productoId,
                Stock = stock
            });

            context.SaveChanges();

            var handler = new ProductoEnStockActualizarEventHandler(context, GetLogger);

            try
            {
                handler.Handle(new ProductoEnStockActualizarComnando
                {
                    Items = new List<ProductoEnStockActualizarItem>() 
                    {
                        new ProductoEnStockActualizarItem 
                        {
                            ProductoId = productoId,
                            Stock = 2,
                            Accion = ProductoEnStockAccion.Substract
                        }
                    }
                }, new CancellationToken()).Wait();

            }
            catch (AggregateException ae)
            {
                var excepcion = ae.GetBaseException();

                if (excepcion is ProductoEnStockActualizarComnandoExcepcion)
                {
                    throw new ProductoEnStockActualizarComnandoExcepcion(excepcion?.InnerException?.Message);
                }
            }
        }

    }
}
