using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Dominio
{
    public class ProductoEnStock
    {
        public int ProductoEnStockId { get; set; }
        public int ProductoId { get; set; }
        public int Stock { get; set; }
    }
}
