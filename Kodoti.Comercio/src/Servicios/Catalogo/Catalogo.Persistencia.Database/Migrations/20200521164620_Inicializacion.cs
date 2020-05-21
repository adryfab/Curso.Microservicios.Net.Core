using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalogo.Persistencia.Database.Migrations
{
    public partial class Inicializacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalogo");

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "Catalogo",
                columns: table => new
                {
                    ProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 500, nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoID);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalogo",
                columns: table => new
                {
                    ProductoEnStockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductoEnStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "Catalogo",
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalogo",
                table: "Productos",
                columns: new[] { "ProductoID", "Descripcion", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Descripcion del producto 1", "Producto 1", 5m },
                    { 73, "Descripcion del producto 73", "Producto 73", 2m },
                    { 72, "Descripcion del producto 72", "Producto 72", 2m },
                    { 71, "Descripcion del producto 71", "Producto 71", 8m },
                    { 70, "Descripcion del producto 70", "Producto 70", 6m },
                    { 69, "Descripcion del producto 69", "Producto 69", 3m },
                    { 68, "Descripcion del producto 68", "Producto 68", 5m },
                    { 67, "Descripcion del producto 67", "Producto 67", 5m },
                    { 66, "Descripcion del producto 66", "Producto 66", 1m },
                    { 65, "Descripcion del producto 65", "Producto 65", 1m },
                    { 64, "Descripcion del producto 64", "Producto 64", 5m },
                    { 63, "Descripcion del producto 63", "Producto 63", 9m },
                    { 62, "Descripcion del producto 62", "Producto 62", 9m },
                    { 61, "Descripcion del producto 61", "Producto 61", 2m },
                    { 60, "Descripcion del producto 60", "Producto 60", 7m },
                    { 59, "Descripcion del producto 59", "Producto 59", 9m },
                    { 58, "Descripcion del producto 58", "Producto 58", 1m },
                    { 57, "Descripcion del producto 57", "Producto 57", 2m },
                    { 56, "Descripcion del producto 56", "Producto 56", 4m },
                    { 55, "Descripcion del producto 55", "Producto 55", 7m },
                    { 54, "Descripcion del producto 54", "Producto 54", 4m },
                    { 53, "Descripcion del producto 53", "Producto 53", 3m },
                    { 74, "Descripcion del producto 74", "Producto 74", 8m },
                    { 52, "Descripcion del producto 52", "Producto 52", 6m },
                    { 75, "Descripcion del producto 75", "Producto 75", 6m },
                    { 77, "Descripcion del producto 77", "Producto 77", 3m },
                    { 98, "Descripcion del producto 98", "Producto 98", 4m },
                    { 97, "Descripcion del producto 97", "Producto 97", 3m },
                    { 96, "Descripcion del producto 96", "Producto 96", 5m },
                    { 95, "Descripcion del producto 95", "Producto 95", 2m },
                    { 94, "Descripcion del producto 94", "Producto 94", 7m },
                    { 93, "Descripcion del producto 93", "Producto 93", 8m },
                    { 92, "Descripcion del producto 92", "Producto 92", 4m },
                    { 91, "Descripcion del producto 91", "Producto 91", 7m },
                    { 90, "Descripcion del producto 90", "Producto 90", 3m },
                    { 89, "Descripcion del producto 89", "Producto 89", 1m },
                    { 88, "Descripcion del producto 88", "Producto 88", 3m },
                    { 87, "Descripcion del producto 87", "Producto 87", 8m },
                    { 86, "Descripcion del producto 86", "Producto 86", 6m },
                    { 85, "Descripcion del producto 85", "Producto 85", 6m },
                    { 84, "Descripcion del producto 84", "Producto 84", 8m },
                    { 83, "Descripcion del producto 83", "Producto 83", 6m },
                    { 82, "Descripcion del producto 82", "Producto 82", 9m },
                    { 81, "Descripcion del producto 81", "Producto 81", 7m },
                    { 80, "Descripcion del producto 80", "Producto 80", 2m },
                    { 79, "Descripcion del producto 79", "Producto 79", 2m },
                    { 78, "Descripcion del producto 78", "Producto 78", 1m },
                    { 76, "Descripcion del producto 76", "Producto 76", 2m },
                    { 51, "Descripcion del producto 51", "Producto 51", 6m },
                    { 50, "Descripcion del producto 50", "Producto 50", 9m },
                    { 49, "Descripcion del producto 49", "Producto 49", 1m },
                    { 22, "Descripcion del producto 22", "Producto 22", 2m },
                    { 21, "Descripcion del producto 21", "Producto 21", 3m },
                    { 20, "Descripcion del producto 20", "Producto 20", 9m },
                    { 19, "Descripcion del producto 19", "Producto 19", 2m },
                    { 18, "Descripcion del producto 18", "Producto 18", 7m },
                    { 17, "Descripcion del producto 17", "Producto 17", 9m },
                    { 16, "Descripcion del producto 16", "Producto 16", 3m },
                    { 15, "Descripcion del producto 15", "Producto 15", 4m },
                    { 14, "Descripcion del producto 14", "Producto 14", 9m },
                    { 13, "Descripcion del producto 13", "Producto 13", 3m },
                    { 12, "Descripcion del producto 12", "Producto 12", 2m },
                    { 11, "Descripcion del producto 11", "Producto 11", 1m },
                    { 10, "Descripcion del producto 10", "Producto 10", 3m },
                    { 9, "Descripcion del producto 9", "Producto 9", 7m },
                    { 8, "Descripcion del producto 8", "Producto 8", 6m },
                    { 7, "Descripcion del producto 7", "Producto 7", 6m },
                    { 6, "Descripcion del producto 6", "Producto 6", 7m },
                    { 5, "Descripcion del producto 5", "Producto 5", 1m },
                    { 4, "Descripcion del producto 4", "Producto 4", 5m },
                    { 3, "Descripcion del producto 3", "Producto 3", 9m },
                    { 2, "Descripcion del producto 2", "Producto 2", 4m },
                    { 23, "Descripcion del producto 23", "Producto 23", 3m },
                    { 24, "Descripcion del producto 24", "Producto 24", 8m },
                    { 25, "Descripcion del producto 25", "Producto 25", 5m },
                    { 26, "Descripcion del producto 26", "Producto 26", 4m },
                    { 48, "Descripcion del producto 48", "Producto 48", 6m },
                    { 47, "Descripcion del producto 47", "Producto 47", 6m },
                    { 46, "Descripcion del producto 46", "Producto 46", 3m },
                    { 45, "Descripcion del producto 45", "Producto 45", 7m },
                    { 44, "Descripcion del producto 44", "Producto 44", 2m },
                    { 43, "Descripcion del producto 43", "Producto 43", 9m },
                    { 42, "Descripcion del producto 42", "Producto 42", 2m },
                    { 41, "Descripcion del producto 41", "Producto 41", 4m },
                    { 40, "Descripcion del producto 40", "Producto 40", 3m },
                    { 39, "Descripcion del producto 39", "Producto 39", 5m },
                    { 99, "Descripcion del producto 99", "Producto 99", 2m },
                    { 38, "Descripcion del producto 38", "Producto 38", 8m },
                    { 36, "Descripcion del producto 36", "Producto 36", 8m },
                    { 35, "Descripcion del producto 35", "Producto 35", 7m },
                    { 34, "Descripcion del producto 34", "Producto 34", 8m },
                    { 33, "Descripcion del producto 33", "Producto 33", 7m },
                    { 32, "Descripcion del producto 32", "Producto 32", 1m },
                    { 31, "Descripcion del producto 31", "Producto 31", 3m },
                    { 30, "Descripcion del producto 30", "Producto 30", 2m },
                    { 29, "Descripcion del producto 29", "Producto 29", 7m },
                    { 28, "Descripcion del producto 28", "Producto 28", 7m },
                    { 27, "Descripcion del producto 27", "Producto 27", 6m },
                    { 37, "Descripcion del producto 37", "Producto 37", 4m },
                    { 100, "Descripcion del producto 100", "Producto 100", 7m }
                });

            migrationBuilder.InsertData(
                schema: "Catalogo",
                table: "Stocks",
                columns: new[] { "ProductoEnStockId", "ProductoId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 17 },
                    { 73, 73, 5 },
                    { 72, 72, 19 },
                    { 71, 71, 0 },
                    { 70, 70, 16 },
                    { 69, 69, 18 },
                    { 68, 68, 5 },
                    { 67, 67, 9 },
                    { 66, 66, 12 },
                    { 65, 65, 13 },
                    { 64, 64, 5 },
                    { 63, 63, 3 },
                    { 62, 62, 7 },
                    { 61, 61, 4 },
                    { 60, 60, 6 },
                    { 59, 59, 9 },
                    { 58, 58, 9 },
                    { 57, 57, 4 },
                    { 56, 56, 7 },
                    { 55, 55, 11 },
                    { 54, 54, 11 },
                    { 53, 53, 10 },
                    { 74, 74, 1 },
                    { 52, 52, 4 },
                    { 75, 75, 14 },
                    { 77, 77, 9 },
                    { 98, 98, 14 },
                    { 97, 97, 10 },
                    { 96, 96, 10 },
                    { 95, 95, 0 },
                    { 94, 94, 15 },
                    { 93, 93, 17 },
                    { 92, 92, 5 },
                    { 91, 91, 7 },
                    { 90, 90, 10 },
                    { 89, 89, 8 },
                    { 88, 88, 13 },
                    { 87, 87, 5 },
                    { 86, 86, 3 },
                    { 85, 85, 19 },
                    { 84, 84, 15 },
                    { 83, 83, 10 },
                    { 82, 82, 11 },
                    { 81, 81, 19 },
                    { 80, 80, 19 },
                    { 79, 79, 11 },
                    { 78, 78, 16 },
                    { 76, 76, 6 },
                    { 51, 51, 0 },
                    { 50, 50, 19 },
                    { 49, 49, 18 },
                    { 22, 22, 9 },
                    { 21, 21, 1 },
                    { 20, 20, 12 },
                    { 19, 19, 5 },
                    { 18, 18, 8 },
                    { 17, 17, 6 },
                    { 16, 16, 14 },
                    { 15, 15, 8 },
                    { 14, 14, 16 },
                    { 13, 13, 4 },
                    { 12, 12, 15 },
                    { 11, 11, 8 },
                    { 10, 10, 0 },
                    { 9, 9, 5 },
                    { 8, 8, 17 },
                    { 7, 7, 16 },
                    { 6, 6, 8 },
                    { 5, 5, 9 },
                    { 4, 4, 11 },
                    { 3, 3, 12 },
                    { 2, 2, 8 },
                    { 23, 23, 4 },
                    { 24, 24, 2 },
                    { 25, 25, 1 },
                    { 26, 26, 2 },
                    { 48, 48, 13 },
                    { 47, 47, 3 },
                    { 46, 46, 1 },
                    { 45, 45, 11 },
                    { 44, 44, 7 },
                    { 43, 43, 0 },
                    { 42, 42, 14 },
                    { 41, 41, 17 },
                    { 40, 40, 4 },
                    { 39, 39, 2 },
                    { 99, 99, 14 },
                    { 38, 38, 7 },
                    { 36, 36, 11 },
                    { 35, 35, 18 },
                    { 34, 34, 19 },
                    { 33, 33, 5 },
                    { 32, 32, 16 },
                    { 31, 31, 7 },
                    { 30, 30, 19 },
                    { 29, 29, 14 },
                    { 28, 28, 8 },
                    { 27, 27, 4 },
                    { 37, 37, 14 },
                    { 100, 100, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProductoID",
                schema: "Catalogo",
                table: "Productos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductoId",
                schema: "Catalogo",
                table: "Stocks",
                column: "ProductoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Productos",
                schema: "Catalogo");
        }
    }
}
