using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedaSystem.Infra.Data.Migrations.InfoMail
{
    public partial class InfoMailMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoMails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    TerapeutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lido = table.Column<bool>(type: "bit", nullable: false),
                    Grupo = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<int>(type: "int", nullable: false),
                    Benchmark = table.Column<bool>(type: "bit", nullable: false),
                    Rascunho = table.Column<bool>(type: "bit", nullable: false),
                    Enviado = table.Column<bool>(type: "bit", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoMails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoMails");
        }
    }
}
