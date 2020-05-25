using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static Catalogo.Comun.Enums;

namespace Catalogo.Servicios.EventHandlers.Command
{
    public class ProductoEnStockActualizarComnando : INotification
    {
        public IEnumerable<ProductoEnStockActualizarItem> Items { get; set; } = new List<ProductoEnStockActualizarItem>();
    }

    public class ProductoEnStockActualizarItem
    {
        public int ProductoId { get; set; }
        public int Stock { get; set; }
        public ProductoEnStockAccion Accion { get; set; }
    }
}
