using Customer.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Customer.Persistencia.Database.Configuracion
{
    public class ClienteConfiguracion
    {
        public List<Persona> ListaPersonas { get; set; }

        public ClienteConfiguracion(EntityTypeBuilder<Cliente> entityBuilder)
        {
            //**Propiedades
            //Setea el campo del ID
            entityBuilder.HasIndex(x => x.ClienteId);
            //Nombre es requerido y tiene un longitud maxima de caracteres
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);

            //Llenando aleatoriamente nombres y apellidos
            var listaPivote = new ObservableCollection<Persona>()
            {
                new Persona(){ Apellido="Ruiz",Nombre="Juan"},
                new Persona(){ Apellido="Pacheco",Nombre="Carlos"},
                new Persona(){ Apellido="Montoya",Nombre="Leidy"},
                new Persona(){ Apellido="Velazques",Nombre="Paola"},
                new Persona(){ Apellido="Torres",Nombre="Juan"},
                new Persona(){ Apellido="Sánchez",Nombre="Diana"},
                new Persona(){ Apellido="García",Nombre="María"},
                new Persona(){ Apellido="Rodríguez",Nombre="Kevin"},
                new Persona(){ Apellido="Andrade",Nombre="Bryan"},
                new Persona(){ Apellido="Flores",Nombre="Ana"}
            };

            var listaFull = from persona in listaPivote
                            from persona2 in listaPivote
                            select new Persona()
                            {
                                Nombre = persona.Nombre,
                                Apellido = persona2.Apellido
                            };

            ListaPersonas = new List<Persona>(listaFull);

            //Llenando los clientes iniciales
            int count = 0;
            var clientes = new List<Cliente>();
            foreach (Persona persona1 in ListaPersonas)
            {
                count++;
                clientes.Add(new Cliente { 
                    ClienteId = count,
                    Nombre = persona1.Nombre + ' ' + persona1.Apellido
                });
            }

            entityBuilder.HasData(clientes);
        }
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
