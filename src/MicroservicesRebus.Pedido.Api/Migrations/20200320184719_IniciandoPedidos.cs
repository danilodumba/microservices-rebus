using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroservicesRebus.Pedido.Api.Migrations
{
    public partial class IniciandoPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    numero = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome_cliente = table.Column<string>(maxLength: 100, nullable: false),
                    data = table.Column<DateTime>(nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.numero);
                });

            migrationBuilder.CreateTable(
                name: "pedidos_itens",
                columns: table => new
                {
                    numero_pedido = table.Column<int>(nullable: false),
                    produto_id = table.Column<int>(nullable: false),
                    nome_produto = table.Column<string>(maxLength: 100, nullable: false),
                    quantidade = table.Column<int>(nullable: false),
                    valor_unitario = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos_itens", x => new { x.numero_pedido, x.produto_id });
                    table.ForeignKey(
                        name: "FK_pedidos_itens_pedidos_numero_pedido",
                        column: x => x.numero_pedido,
                        principalTable: "pedidos",
                        principalColumn: "numero",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pedidos_itens");

            migrationBuilder.DropTable(
                name: "pedidos");
        }
    }
}
