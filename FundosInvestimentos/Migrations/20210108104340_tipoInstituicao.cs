using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundosInvestimentos.Migrations
{
    public partial class tipoInstituicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundoDistribuido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    CNPJ = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundoDistribuido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoInstituicao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInstituicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: true),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    TipoInstituicaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnoCriacao = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instituicao_TipoInstituicao_TipoInstituicaoId",
                        column: x => x.TipoInstituicaoId,
                        principalTable: "TipoInstituicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fundos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: true),
                    Saldo = table.Column<double>(type: "double precision", nullable: false),
                    RazaoSocialGestor = table.Column<string>(type: "text", nullable: true),
                    RazaoSocialAdministrador = table.Column<string>(type: "text", nullable: true),
                    RazaoSocialDistribuidor = table.Column<string>(type: "text", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CodigoAnbima = table.Column<string>(type: "text", nullable: true),
                    InstituicaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fundos_Instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundoFundosDistribuidos",
                columns: table => new
                {
                    FundoId = table.Column<Guid>(type: "uuid", nullable: false),
                    FundoDistribuidoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundoFundosDistribuidos", x => new { x.FundoId, x.FundoDistribuidoId });
                    table.ForeignKey(
                        name: "FK_FundoFundosDistribuidos_FundoDistribuido_FundoDistribuidoId",
                        column: x => x.FundoDistribuidoId,
                        principalTable: "FundoDistribuido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundoFundosDistribuidos_Fundos_FundoId",
                        column: x => x.FundoId,
                        principalTable: "Fundos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoInstituicao",
                columns: new[] { "Id", "CreatedAt", "Tipo", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("d525c7b9-1aab-4fb0-83df-b73bc35e689d"), new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(4638), "Administrador", new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(4638) },
                    { new Guid("30f7d1fc-cd61-4dcf-95d3-924c0067adf9"), new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(6751), "Gestor", new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(6751) },
                    { new Guid("872470d4-b566-465a-a1fc-783a3fbb65f3"), new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(6775), "Distribuidor", new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(6775) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundoFundosDistribuidos_FundoDistribuidoId",
                table: "FundoFundosDistribuidos",
                column: "FundoDistribuidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fundos_InstituicaoId",
                table: "Fundos",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_TipoInstituicaoId",
                table: "Instituicao",
                column: "TipoInstituicaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundoFundosDistribuidos");

            migrationBuilder.DropTable(
                name: "FundoDistribuido");

            migrationBuilder.DropTable(
                name: "Fundos");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TipoInstituicao");
        }
    }
}
