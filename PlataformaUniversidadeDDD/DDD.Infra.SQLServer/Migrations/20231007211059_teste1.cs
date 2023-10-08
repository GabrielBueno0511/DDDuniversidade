using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infra.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class teste1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atleta",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [UserSequence]"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atleta", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "campeonato",
                columns: table => new
                {
                    EsporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEsporte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campeonato", x => x.EsporteId);
                });

            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    CampeonatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCampeonato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsporteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => x.CampeonatoId);
                });

            migrationBuilder.CreateTable(
                name: "ContratoAtletas",
                columns: table => new
                {
                    AtletaId = table.Column<int>(type: "int", nullable: false),
                    EsporteId = table.Column<int>(type: "int", nullable: false),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    TempoContrato = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoAtletas", x => new { x.AtletaId, x.EsporteId });
                    table.ForeignKey(
                        name: "FK_ContratoAtletas_Atleta_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atleta",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContratoAtletas_campeonato_EsporteId",
                        column: x => x.EsporteId,
                        principalTable: "campeonato",
                        principalColumn: "EsporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratoAtletas_EsporteId",
                table: "ContratoAtletas",
                column: "EsporteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campeonatos");

            migrationBuilder.DropTable(
                name: "ContratoAtletas");

            migrationBuilder.DropTable(
                name: "Atleta");

            migrationBuilder.DropTable(
                name: "campeonato");
        }
    }
}
