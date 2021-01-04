using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundosInvestimentos.Migrations
{
    public partial class CargaInicialTipoInstituicao : Migration
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
                    { new Guid("cb05730e-4f5a-4e87-a208-c1f1ba86a9a1"), new DateTime(2021, 1, 4, 13, 3, 38, 934, DateTimeKind.Utc).AddTicks(6751), "Administrador" },
                    { new Guid("26bfecb7-2344-45fc-9866-8d1a38758c72"), new DateTime(2021, 1, 4, 13, 3, 38, 934, DateTimeKind.Utc).AddTicks(8274), "Gestor" },
                    { new Guid("8cbd14de-1983-4774-8bdd-4f73a5a75ca2"), new DateTime(2021, 1, 4, 13, 3, 38, 934, DateTimeKind.Utc).AddTicks(8297), "Distribuidor" }
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
