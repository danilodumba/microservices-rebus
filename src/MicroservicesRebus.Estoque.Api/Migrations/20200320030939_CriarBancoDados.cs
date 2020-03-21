using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroservicesRebus.Estoque.Api.Migrations
{
    public partial class CriarBancoDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    quantidadeEstoque = table.Column<int>(nullable: false),
                    valor = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "produtos",
                columns: new[] { "id", "nome", "quantidadeEstoque", "valor" },
                values: new object[,]
                {
                    { 1, "BMW X1", 100, 200000m },
                    { 2, "BMW 320", 100, 250000m },
                    { 3, "MERCEDES A200", 100, 290000m },
                    { 4, "LAND EVOQUE", 100, 350000m },
                    { 5, "FERRARI F40", 100, 1250000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produtos");
        }
    }
}
