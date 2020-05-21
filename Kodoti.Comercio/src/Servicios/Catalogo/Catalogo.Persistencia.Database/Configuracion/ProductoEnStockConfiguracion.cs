using Catalogo.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Persistencia.Database.Configuracion
{
    public class ProductoEnStockConfiguracion
    {
        public ProductoEnStockConfiguracion(EntityTypeBuilder<ProductoEnStock> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ProductoEnStockId);

            var random = new Random();
            var stocks = new List<ProductoEnStock>();

            for (var i = 1; i <= 100; i++)
            {
                stocks.Add(new ProductoEnStock
                {
                    ProductoEnStockId = i,
                    ProductoId = i,
                    Stock = random.Next(0, 20)
                });
            }

            entityBuilder.HasData(stocks);
        }
    }
}
