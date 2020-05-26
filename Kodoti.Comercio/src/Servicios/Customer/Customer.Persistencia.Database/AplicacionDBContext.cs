using Customer.Dominio;
using Customer.Persistencia.Database.Configuracion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Persistencia.Database
{
    public class AplicacionDBContext : DbContext
    {
        public AplicacionDBContext (DbContextOptions<AplicacionDBContext> opciones) 
            : base(opciones) 
        {

        }

        //Tablas
        public DbSet<Cliente> Cliente { get; set; }

        //Cuando crea el modelo (tablas)
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Se crea la configuracion por defecto
            base.OnModelCreating(builder);

            //Esquema de las tablas
            builder.HasDefaultSchema("Customer");
            
            //Se asigna la configuracion personalizada
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ClienteConfiguracion(modelBuilder.Entity<Cliente>());
        }
    }
}
