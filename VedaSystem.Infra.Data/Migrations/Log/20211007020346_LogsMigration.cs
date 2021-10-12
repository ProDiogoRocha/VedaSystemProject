using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedaSystem.Infra.Data.Migrations.Log
{
    public partial class LogsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeComputador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Controller_Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Servico_Metodo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repositorio_Metodo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetoJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Erro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Excecao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
