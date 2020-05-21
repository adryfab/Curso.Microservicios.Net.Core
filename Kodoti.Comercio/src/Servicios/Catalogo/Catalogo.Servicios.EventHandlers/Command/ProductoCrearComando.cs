using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Servicios.EventHandlers.Command
{
    public class ProductoCrearComando : INotification
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
