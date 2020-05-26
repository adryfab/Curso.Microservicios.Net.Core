using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Persistencia.Database.Migrations
{
    public partial class iniciar3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "Customer",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "Cliente",
                columns: new[] { "ClienteId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Juan Ruiz" },
                    { 73, "Kevin Montoya" },
                    { 72, "Kevin Pacheco" },
                    { 71, "Kevin Ruiz" },
                    { 70, "María Flores" },
                    { 69, "María Andrade" },
                    { 68, "María Rodríguez" },
                    { 67, "María García" },
                    { 66, "María Sánchez" },
                    { 65, "María Torres" },
                    { 64, "María Velazques" },
                    { 63, "María Montoya" },
                    { 62, "María Pacheco" },
                    { 61, "María Ruiz" },
                    { 60, "Diana Flores" },
                    { 59, "Diana Andrade" },
                    { 58, "Diana Rodríguez" },
                    { 57, "Diana García" },
                    { 56, "Diana Sánchez" },
                    { 55, "Diana Torres" },
                    { 54, "Diana Velazques" },
                    { 53, "Diana Montoya" },
                    { 74, "Kevin Velazques" },
                    { 52, "Diana Pacheco" },
                    { 75, "Kevin Torres" },
                    { 77, "Kevin García" },
                    { 98, "Ana Rodríguez" },
                    { 97, "Ana García" },
                    { 96, "Ana Sánchez" },
                    { 95, "Ana Torres" },
                    { 94, "Ana Velazques" },
                    { 93, "Ana Montoya" },
                    { 92, "Ana Pacheco" },
                    { 91, "Ana Ruiz" },
                    { 90, "Bryan Flores" },
                    { 89, "Bryan Andrade" },
                    { 88, "Bryan Rodríguez" },
                    { 87, "Bryan García" },
                    { 86, "Bryan Sánchez" },
                    { 85, "Bryan Torres" },
                    { 84, "Bryan Velazques" },
                    { 83, "Bryan Montoya" },
                    { 82, "Bryan Pacheco" },
                    { 81, "Bryan Ruiz" },
                    { 80, "Kevin Flores" },
                    { 79, "Kevin Andrade" },
                    { 78, "Kevin Rodríguez" },
                    { 76, "Kevin Sánchez" },
                    { 51, "Diana Ruiz" },
                    { 50, "Juan Flores" },
                    { 49, "Juan Andrade" },
                    { 22, "Leidy Pacheco" },
                    { 21, "Leidy Ruiz" },
                    { 20, "Carlos Flores" },
                    { 19, "Carlos Andrade" },
                    { 18, "Carlos Rodríguez" },
                    { 17, "Carlos García" },
                    { 16, "Carlos Sánchez" },
                    { 15, "Carlos Torres" },
                    { 14, "Carlos Velazques" },
                    { 13, "Carlos Montoya" },
                    { 12, "Carlos Pacheco" },
                    { 11, "Carlos Ruiz" },
                    { 10, "Juan Flores" },
                    { 9, "Juan Andrade" },
                    { 8, "Juan Rodríguez" },
                    { 7, "Juan García" },
                    { 6, "Juan Sánchez" },
                    { 5, "Juan Torres" },
                    { 4, "Juan Velazques" },
                    { 3, "Juan Montoya" },
                    { 2, "Juan Pacheco" },
                    { 23, "Leidy Montoya" },
                    { 24, "Leidy Velazques" },
                    { 25, "Leidy Torres" },
                    { 26, "Leidy Sánchez" },
                    { 48, "Juan Rodríguez" },
                    { 47, "Juan García" },
                    { 46, "Juan Sánchez" },
                    { 45, "Juan Torres" },
                    { 44, "Juan Velazques" },
                    { 43, "Juan Montoya" },
                    { 42, "Juan Pacheco" },
                    { 41, "Juan Ruiz" },
                    { 40, "Paola Flores" },
                    { 39, "Paola Andrade" },
                    { 99, "Ana Andrade" },
                    { 38, "Paola Rodríguez" },
                    { 36, "Paola Sánchez" },
                    { 35, "Paola Torres" },
                    { 34, "Paola Velazques" },
                    { 33, "Paola Montoya" },
                    { 32, "Paola Pacheco" },
                    { 31, "Paola Ruiz" },
                    { 30, "Leidy Flores" },
                    { 29, "Leidy Andrade" },
                    { 28, "Leidy Rodríguez" },
                    { 27, "Leidy García" },
                    { 37, "Paola García" },
                    { 100, "Ana Flores" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ClienteId",
                schema: "Customer",
                table: "Cliente",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "Customer");
        }
    }
}
