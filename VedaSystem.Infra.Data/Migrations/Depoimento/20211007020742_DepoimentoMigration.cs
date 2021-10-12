using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedaSystem.Infra.Data.Migrations.Depoimento
{
    public partial class DepoimentoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depoimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantidadeEstrelas = table.Column<int>(type: "int", nullable: false),
                    Avaliação = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depoimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depoimentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depoimentos_UsuarioId",
                table: "Depoimentos",
                column: "UsuarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depoimentos");
        }
    }
}
