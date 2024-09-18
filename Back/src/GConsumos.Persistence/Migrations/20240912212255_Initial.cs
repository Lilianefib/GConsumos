using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GConsumos.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedidorId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataMedicao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    leitura = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true),
                    Localizacao = table.Column<string>(type: "TEXT", nullable: true),
                    Unidade = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    Unidade = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Unidade = table.Column<string>(type: "TEXT", nullable: true),
                    PrecoUnitario = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoradoresMedidores",
                columns: table => new
                {
                    MoradorId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedidorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoradoresMedidores", x => new { x.MoradorId, x.MedidorId });
                    table.ForeignKey(
                        name: "FK_MoradoresMedidores_Medidores_MedidorId",
                        column: x => x.MedidorId,
                        principalTable: "Medidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoradoresMedidores_Moradores_MoradorId",
                        column: x => x.MoradorId,
                        principalTable: "Moradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedidorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalConsumo = table.Column<int>(type: "INTEGER", nullable: false),
                    Competencia = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumos_Medidores_MedidorId",
                        column: x => x.MedidorId,
                        principalTable: "Medidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumos_MedidorId",
                table: "Consumos",
                column: "MedidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumos_ProdutoId",
                table: "Consumos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_MoradoresMedidores_MedidorId",
                table: "MoradoresMedidores",
                column: "MedidorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoradoresMedidores_MoradorId",
                table: "MoradoresMedidores",
                column: "MoradorId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumos");

            migrationBuilder.DropTable(
                name: "Medicoes");

            migrationBuilder.DropTable(
                name: "MoradoresMedidores");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Medidores");

            migrationBuilder.DropTable(
                name: "Moradores");
        }
    }
}
