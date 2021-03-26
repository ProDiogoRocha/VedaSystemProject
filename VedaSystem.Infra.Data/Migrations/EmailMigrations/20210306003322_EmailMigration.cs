using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedaSystem.Infra.Data.Migrations.EmailMigrations
{
    public partial class EmailMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    RedeSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terapeutas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeDeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmeSenha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsApp = table.Column<bool>(type: "bit", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    Apresentacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terapeutas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerapiaPrincipais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerapiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NomeTerapia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerapiaPrincipais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terapias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeTerapia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terapias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerapeutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnableSsl = table.Column<bool>(type: "bit", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    DeliveryMethod = table.Column<int>(type: "int", nullable: false),
                    UseDefaultCredentials = table.Column<bool>(type: "bit", nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBodyHtml = table.Column<bool>(type: "bit", nullable: false),
                    Smtp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Terapeutas_Id",
                        column: x => x.Id,
                        principalTable: "Terapeutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerapeutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reservado = table.Column<bool>(type: "bit", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horarios_Terapeutas_TerapeutaId",
                        column: x => x.TerapeutaId,
                        principalTable: "Terapeutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteTerapeuta",
                columns: table => new
                {
                    PacientesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerapeutasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteTerapeuta", x => new { x.PacientesId, x.TerapeutasId });
                    table.ForeignKey(
                        name: "FK_PacienteTerapeuta_Pacientes_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteTerapeuta_Terapeutas_TerapeutasId",
                        column: x => x.TerapeutasId,
                        principalTable: "Terapeutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescricoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TerapeutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataDaPrescricao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidadeDaPrescricao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescricoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescricoes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescricoes_Terapeutas_TerapeutaId",
                        column: x => x.TerapeutaId,
                        principalTable: "Terapeutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transmissoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextoAntesDoVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoDeIncorporacaoDeVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextoDepoisDoVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rodape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    TerapeutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transmissoes_Terapeutas_TerapeutaId",
                        column: x => x.TerapeutaId,
                        principalTable: "Terapeutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerapeutaTerapiaPrincipal",
                columns: table => new
                {
                    TerapeutasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerapiasPrincipaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerapeutaTerapiaPrincipal", x => new { x.TerapeutasId, x.TerapiasPrincipaisId });
                    table.ForeignKey(
                        name: "FK_TerapeutaTerapiaPrincipal_Terapeutas_TerapeutasId",
                        column: x => x.TerapeutasId,
                        principalTable: "Terapeutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerapeutaTerapiaPrincipal_TerapiaPrincipais_TerapiasPrincipaisId",
                        column: x => x.TerapiasPrincipaisId,
                        principalTable: "TerapiaPrincipais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    DiaMes = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    TerapiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TerapeutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TerapiaPrincipalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Terapeutas_TerapeutaId",
                        column: x => x.TerapeutaId,
                        principalTable: "Terapeutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_TerapiaPrincipais_TerapiaPrincipalId",
                        column: x => x.TerapiaPrincipalId,
                        principalTable: "TerapiaPrincipais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Terapias_TerapiaId",
                        column: x => x.TerapiaId,
                        principalTable: "Terapias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTerapias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstoqueMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TerapiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TerapiaPrincipalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTerapias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialTerapias_TerapiaPrincipais_TerapiaPrincipalId",
                        column: x => x.TerapiaPrincipalId,
                        principalTable: "TerapiaPrincipais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialTerapias_Terapias_TerapiaId",
                        column: x => x.TerapiaId,
                        principalTable: "Terapias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TerapeutaTerapia",
                columns: table => new
                {
                    TerapeutasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerapiasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerapeutaTerapia", x => new { x.TerapeutasId, x.TerapiasId });
                    table.ForeignKey(
                        name: "FK_TerapeutaTerapia_Terapeutas_TerapeutasId",
                        column: x => x.TerapeutasId,
                        principalTable: "Terapeutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerapeutaTerapia_Terapias_TerapiasId",
                        column: x => x.TerapiasId,
                        principalTable: "Terapias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tratamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    DescricaoTratamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeidcamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Medicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescricaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamentos_Prescricoes_PrescricaoId",
                        column: x => x.PrescricaoId,
                        principalTable: "Prescricoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_PacienteId",
                table: "Agendas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_TerapeutaId",
                table: "Agendas",
                column: "TerapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_TerapiaId",
                table: "Agendas",
                column: "TerapiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_TerapiaPrincipalId",
                table: "Agendas",
                column: "TerapiaPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_TerapeutaId",
                table: "Horarios",
                column: "TerapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTerapias_TerapiaId",
                table: "MaterialTerapias",
                column: "TerapiaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTerapias_TerapiaPrincipalId",
                table: "MaterialTerapias",
                column: "TerapiaPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteTerapeuta_TerapeutasId",
                table: "PacienteTerapeuta",
                column: "TerapeutasId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescricoes_PacienteId",
                table: "Prescricoes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescricoes_TerapeutaId",
                table: "Prescricoes",
                column: "TerapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_TerapeutaTerapia_TerapiasId",
                table: "TerapeutaTerapia",
                column: "TerapiasId");

            migrationBuilder.CreateIndex(
                name: "IX_TerapeutaTerapiaPrincipal_TerapiasPrincipaisId",
                table: "TerapeutaTerapiaPrincipal",
                column: "TerapiasPrincipaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Transmissoes_TerapeutaId",
                table: "Transmissoes",
                column: "TerapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamentos_PrescricaoId",
                table: "Tratamentos",
                column: "PrescricaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "MaterialTerapias");

            migrationBuilder.DropTable(
                name: "PacienteTerapeuta");

            migrationBuilder.DropTable(
                name: "TerapeutaTerapia");

            migrationBuilder.DropTable(
                name: "TerapeutaTerapiaPrincipal");

            migrationBuilder.DropTable(
                name: "Transmissoes");

            migrationBuilder.DropTable(
                name: "Tratamentos");

            migrationBuilder.DropTable(
                name: "Terapias");

            migrationBuilder.DropTable(
                name: "TerapiaPrincipais");

            migrationBuilder.DropTable(
                name: "Prescricoes");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Terapeutas");
        }
    }
}
