using System;

namespace Catalogo.Dominio
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public ProductoEnStock Stock { get; set; }
    }
}
