using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Servicios.EventHandler.Comando
{
    public class ClienteCrearComando : INotification
    {
        public string Nombre { get; set; }
    }
}
