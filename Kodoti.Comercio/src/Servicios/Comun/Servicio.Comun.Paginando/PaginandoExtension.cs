using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Servicio.Comun.Coleccion.DataColeccion;

namespace Servicio.Comun.Paginando
{
    public static class PaginandoExtension
    {
        public static async Task<DataCollection<T>> GetPagedAsync<T> (
            this IQueryable<T> query,
            int pagina,
            int take)
        {
            var originalPaginas = pagina;

            pagina--;

            if (pagina > 0)
                pagina = pagina * take;

            var resultado = new DataCollection<T>
            {
                Items = await query.Skip(pagina).Take(take).ToListAsync(),
                Total = await query.CountAsync(),
                Pagina = originalPaginas
            };

            if (resultado.Total > 0)
            {
                resultado.Paginas = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(resultado.Total)/take));
            }

            return resultado;
        }
    }
}
