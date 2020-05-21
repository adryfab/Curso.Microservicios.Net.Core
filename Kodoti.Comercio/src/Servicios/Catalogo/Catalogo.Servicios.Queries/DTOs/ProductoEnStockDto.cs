using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Servicios.Queries.DTOs
{
    public class ProductoEnStockDto
    {
        public int ProductoEnStockId { get; set; }
        public int ProductoId { get; set; }
        public int Stock { get; set; }
    }
}
