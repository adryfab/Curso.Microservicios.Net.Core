using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Servicios.EventHandlers.Excepciones
{
    public class ProductoEnStockActualizarComnandoExcepcion : Exception
    {
        public ProductoEnStockActualizarComnandoExcepcion(string mensaje)
            : base(mensaje)
        {

        }
    }
}
