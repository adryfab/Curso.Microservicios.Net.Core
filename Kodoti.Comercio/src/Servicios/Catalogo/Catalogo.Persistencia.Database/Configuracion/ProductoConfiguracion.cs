using Catalogo.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Persistencia.Database.Configuracion
{
    public class ProductoConfiguracion
    {
        public ProductoConfiguracion(EntityTypeBuilder<Producto> entityBuilder)
        {
            //**Propiedades
            //Setea el campo del ID
            entityBuilder.HasIndex(x => x.ProductoID); 
            //Nombre es requerido y tiene un longitud maxima de 100 caracteres
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            //Descripcion es requerido y tiene un longitud maxima de 500 caracteres
            entityBuilder.Property(x => x.Descripcion).IsRequired().HasMaxLength(500);

            //Productos iniciales
            var productos = new List<Producto>();
            var random = new Random();

            for (var i = 1; i <= 100; i++)
            {
                productos.Add(new Producto
                {
                    ProductoID = i,
                    Nombre = $"Producto {i}",
                    Descripcion = $"Descripcion del producto {i}",
                    Precio = random.Next(100, 1000) / 100,
                });
            }

            entityBuilder.HasData(productos);
        }
    }
}
