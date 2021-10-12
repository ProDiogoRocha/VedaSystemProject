using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VedaSystem.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Composicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laboratorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoMedicamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                });

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
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeDeUsuario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ConfirmeSenha = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    WhatsApp = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Site = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    Apresentacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
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
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
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
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBodyHtml = table.Column<bool>(type: "bit", nullable: false),
                    Smtp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Terapeutas_TerapeutaId",
                        column: x => x.TerapeutaId,
                        principalTable: "Terapeutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaClinicaPaciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerapeutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profissao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuixasPrincipais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sintomas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempoSintomas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PioramOuMelhoram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PulsoVikriti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaracteristicasLingua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaracteristicasUnhas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AspectoFisico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Palpacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraQueAcorda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OqueFazAoAcordar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraQueDorme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComoEOSono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OQueFazACadaHoraDoDia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OQueComeACadaRefeicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorariosDasRefeicoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apetite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotivoFome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempoFomeNovamente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdSuor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheiroSuor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsistenciaSuor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdFezes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheiroFezes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorFezes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsistenciaFezes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdUrina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorUrina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheiroUrina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesconfortoEliminacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoExercicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Regularidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdHorasPorDia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeSenteBemAoAcordar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeSenteBemAoLongoDoDia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenteDisposicaoSeExercitar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegularidadeDuracaoDoCiclo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fluxo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlgumDisturbio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenteQueDormeBem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcordaANoiteQuantasVezesPorQue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeSenteRestauradoPelaManha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SonhaComoSaoOsSonhos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TomaAlgumMedicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FazUsoDeAlgumaSubstânciaViciante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlgumOutroDadoImportante = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaClinicaPaciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichaClinicaPaciente_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FichaClinicaPaciente_Terapeutas_TerapeutaId",
                        column: x => x.TerapeutaId,
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
                    TerapiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracaoConsultaEmMinutos = table.Column<int>(type: "int", nullable: false),
                    Intervalo = table.Column<int>(type: "int", nullable: false),
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
                name: "QuestionarioPosDiagnostico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerapeutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodoShamana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeguiuAdequadamente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiosTratamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QueixasPersistentes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaracteristicasFezes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaracteristicasUrina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apetite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disposição = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComentarioAdicional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionarioPosDiagnostico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionarioPosDiagnostico_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionarioPosDiagnostico_Terapeutas_TerapeutaId",
                        column: x => x.TerapeutaId,
                        principalTable: "Terapeutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IdsDepoimentos = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTerapias", x => x.Id);
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
                name: "MedicamentoPrescricao",
                columns: table => new
                {
                    MedicamentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescricoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoPrescricao", x => new { x.MedicamentosId, x.PrescricoesId });
                    table.ForeignKey(
                        name: "FK_MedicamentoPrescricao_Medicamentos_MedicamentosId",
                        column: x => x.MedicamentosId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentoPrescricao_Prescricoes_PrescricoesId",
                        column: x => x.PrescricoesId,
                        principalTable: "Prescricoes",
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
                name: "IX_Emails_TerapeutaId",
                table: "Emails",
                column: "TerapeutaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FichaClinicaPaciente_PacienteId",
                table: "FichaClinicaPaciente",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_FichaClinicaPaciente_TerapeutaId",
                table: "FichaClinicaPaciente",
                column: "TerapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_TerapeutaId",
                table: "Horarios",
                column: "TerapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTerapias_TerapiaId",
                table: "MaterialTerapias",
                column: "TerapiaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoPrescricao_PrescricoesId",
                table: "MedicamentoPrescricao",
                column: "PrescricoesId");

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
                name: "IX_QuestionarioPosDiagnostico_PacienteId",
                table: "QuestionarioPosDiagnostico",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionarioPosDiagnostico_TerapeutaId",
                table: "QuestionarioPosDiagnostico",
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
                name: "FichaClinicaPaciente");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "MaterialTerapias");

            migrationBuilder.DropTable(
                name: "MedicamentoPrescricao");

            migrationBuilder.DropTable(
                name: "PacienteTerapeuta");

            migrationBuilder.DropTable(
                name: "QuestionarioPosDiagnostico");

            migrationBuilder.DropTable(
                name: "TerapeutaTerapia");

            migrationBuilder.DropTable(
                name: "TerapeutaTerapiaPrincipal");

            migrationBuilder.DropTable(
                name: "Transmissoes");

            migrationBuilder.DropTable(
                name: "Tratamentos");

            migrationBuilder.DropTable(
                name: "Medicamentos");

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
