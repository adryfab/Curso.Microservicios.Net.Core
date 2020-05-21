using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.Comun.Coleccion
{
    public class DataColeccion
    {
        public class DataCollection<T>
        {
            public bool HasItems
            {
                get
                {
                    return Items != null && Items.Any();
                }
            }

            public IEnumerable<T> Items { get; set; }
            public int Total { get; set; }
            public int Pagina { get; set; }
            public int Paginas { get; set; }
        }
    }
}
