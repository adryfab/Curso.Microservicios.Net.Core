using System;

namespace Catalogo.Servicios.Queries.DTOs
{
    public class ProductoDto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public ProductoEnStockDto Stock { get; set; }
    }
}
