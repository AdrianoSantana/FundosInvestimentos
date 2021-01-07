using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundosInvestimentos.Migrations
{
    public partial class AnoCriacaoInstituicao : Migration
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
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: true)
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
                columns: new[] { "Id", "CreatedAt", "Tipo" },
                values: new object[,]
                {
                    { new Guid("00c8790c-4413-4793-80eb-63fb9eb3641b"), new DateTime(2021, 1, 7, 12, 9, 38, 180, DateTimeKind.Utc).AddTicks(5267), "Administrador" },
                    { new Guid("dc3439b0-b07e-456b-b5e8-9b11c37ee1b2"), new DateTime(2021, 1, 7, 12, 9, 38, 180, DateTimeKind.Utc).AddTicks(6749), "Gestor" },
                    { new Guid("a61fb58f-4480-49bc-aec4-de7c7cd2994c"), new DateTime(2021, 1, 7, 12, 9, 38, 180, DateTimeKind.Utc).AddTicks(6772), "Distribuidor" }
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
