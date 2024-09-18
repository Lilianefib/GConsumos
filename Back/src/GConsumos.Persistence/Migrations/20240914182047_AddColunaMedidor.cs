using Microsoft.EntityFrameworkCore.Migrations;

namespace GConsumos.Persistence.Migrations
{
    public partial class AddColunaMedidor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MoradoresMedidores_MoradorId",
                table: "MoradoresMedidores");

            migrationBuilder.AddColumn<string>(
                name: "numeroMedidor",
                table: "Medidores",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numeroMedidor",
                table: "Medidores");

            migrationBuilder.CreateIndex(
                name: "IX_MoradoresMedidores_MoradorId",
                table: "MoradoresMedidores",
                column: "MoradorId",
                unique: true);
        }
    }
}
