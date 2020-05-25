using Catalogo.Persistencia.Database;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Pruebas.Config
{
    public static class ApplicationDbContextInMemory
    {
        public static AplicacionDBContext Get ()
        {
            var options = new DbContextOptionsBuilder<AplicacionDBContext>()
                .UseInMemoryDatabase(databaseName:$"Catalogo.Db")
                .Options;

            return new AplicacionDBContext(options);
        }
    }
}
