using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Catalogo.Dominio;
using Catalogo.Persistencia.Database.Configuracion;

namespace Catalogo.Persistencia.Database
{
    public class AplicacionDBContext : DbContext
    {
        public AplicacionDBContext(
            DbContextOptions<AplicacionDBContext> opciones) : base(opciones)
        {

        }

        //Tablas
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoEnStock> Stocks { get; set; }

        //Cuando crea el modelo (tablas)
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Se crea la configuracion por defecto
            base.OnModelCreating(builder);

            //Esquema de las tablas
            builder.HasDefaultSchema("Catalogo");

            //Se asigna la configuracion personalizada
            ModelConfig(builder);
        }

        //Seteando las configuraciones
        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ProductoConfiguracion(modelBuilder.Entity<Producto>());
            new ProductoEnStockConfiguracion(modelBuilder.Entity<ProductoEnStock>());
        }
    }
}
