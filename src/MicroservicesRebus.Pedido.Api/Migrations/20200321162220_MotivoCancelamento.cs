using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroservicesRebus.Pedido.Api.Migrations
{
    public partial class MotivoCancelamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "motivo_cancelamento",
                table: "pedidos",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "motivo_cancelamento",
                table: "pedidos");
        }
    }
}
