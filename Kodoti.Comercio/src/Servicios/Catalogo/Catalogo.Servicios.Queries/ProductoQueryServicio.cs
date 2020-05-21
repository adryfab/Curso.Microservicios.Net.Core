using Catalogo.Persistencia.Database;
using Catalogo.Servicios.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Servicio.Comun.Mapping;
using Servicio.Comun.Paginando;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Servicio.Comun.Coleccion.DataColeccion;

namespace Catalogo.Servicios.Queries
{
    public interface IProductoQueryServicio
    {
        Task<DataCollection<ProductoDto>> GetAllAsync(int pagina, int take, IEnumerable<int> productos = null);
        Task<ProductoDto> GetAsync(int id);
    }

    public class ProductoQueryServicio : IProductoQueryServicio
    {
        private readonly AplicacionDBContext _context;
        public ProductoQueryServicio(AplicacionDBContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<ProductoDto>> GetAllAsync(int pagina, int take, IEnumerable<int> productos = null) 
        {
            var colecion = await _context.Productos
                                .Where(x => productos == null || productos.Contains(x.ProductoID))
                                .OrderByDescending(x => x.ProductoID)
                                .GetPagedAsync(pagina, take);

            return colecion.MapTo<DataCollection<ProductoDto>>();
        }

        public async Task<ProductoDto> GetAsync(int id)
        {
            return (await _context.Productos.SingleAsync(x => x.ProductoID == id)).MapTo<ProductoDto>();
        }
    }
}
