using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    IdFuncionario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Matricula = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cargo = table.Column<int>(type: "integer", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.IdFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    IdLaboratorio = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    QtdComputadores = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.IdLaboratorio);
                });

            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    IdNotebook = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroPatrimonio = table.Column<int>(type: "integer", nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.IdNotebook);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    IdSala = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    QtdLugares = table.Column<int>(type: "integer", nullable: false),
                    TemProjetor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.IdSala);
                });

            migrationBuilder.CreateTable(
                name: "Alocacoes",
                columns: table => new
                {
                    IdAlocacao = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FuncionarioId = table.Column<long>(type: "bigint", nullable: false),
                    IdRecurso = table.Column<long>(type: "bigint", nullable: false),
                    TipoRecurso = table.Column<int>(type: "integer", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alocacoes", x => x.IdAlocacao);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "IdFuncionario", "Cargo", "DataAdmissao", "Matricula", "Nome" },
                values: new object[,]
                {
                    { 1L, 2, new DateTime(2025, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), 100167, "Nicholas Navarro" },
                    { 2L, 2, new DateTime(2025, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), 100168, "Júlia Schivisnky" },
                    { 3L, 2, new DateTime(2025, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), 100169, "Ellen" },
                    { 4L, 2, new DateTime(2025, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), 100170, "Henrique Coralles" },
                    { 5L, 1, new DateTime(2025, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), 101010, "MR Gabriel Velloso" }
                });

            migrationBuilder.InsertData(
                table: "Laboratorios",
                columns: new[] { "IdLaboratorio", "Descricao", "Nome", "QtdComputadores" },
                values: new object[,]
                {
                    { 1L, "Computadores Core i5, 8GB RAM", "Lab Redes", 20 },
                    { 2L, "Core i7, 16GB RAM, SSD", "Lab Desenvolvimento", 25 },
                    { 3L, "Core i5, 8GB RAM, kits de hardware", "Lab Hardware", 15 },
                    { 4L, "Core i9, 32GB RAM, GPU dedicada", "Lab Inteligência Artificial", 10 },
                    { 5L, "Core i5, 16GB RAM", "Lab Banco de Dados", 18 }
                });

            migrationBuilder.InsertData(
                table: "Notebooks",
                columns: new[] { "IdNotebook", "DataAquisicao", "Descricao", "NumeroPatrimonio" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), "Dell Inspiron i5", 1001 },
                    { 2L, new DateTime(2022, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), "HP Elitebook i7", 1002 },
                    { 3L, new DateTime(2024, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), "Lenovo Thinkpad i5", 1003 },
                    { 4L, new DateTime(2021, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), "Acer Aspire i3", 1004 },
                    { 5L, new DateTime(2019, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), "Macbook Air M1", 1005 }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "IdSala", "Numero", "QtdLugares", "TemProjetor" },
                values: new object[,]
                {
                    { 1L, 101, 30, true },
                    { 2L, 102, 20, false },
                    { 3L, 103, 25, true },
                    { 4L, 104, 15, false },
                    { 5L, 105, 40, true }
                });

            migrationBuilder.InsertData(
                table: "Alocacoes",
                columns: new[] { "IdAlocacao", "DataCriacao", "DataReserva", "FuncionarioId", "IdRecurso", "TipoRecurso" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 27, 3, 0, 0, 0, DateTimeKind.Utc), 1L, 1L, 0 },
                    { 2L, new DateTime(2025, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 28, 3, 0, 0, 0, DateTimeKind.Utc), 2L, 2L, 2 },
                    { 3L, new DateTime(2025, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 29, 3, 0, 0, 0, DateTimeKind.Utc), 3L, 4L, 1 },
                    { 4L, new DateTime(2025, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 30, 3, 0, 0, 0, DateTimeKind.Utc), 4L, 4L, 0 },
                    { 5L, new DateTime(2025, 8, 20, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 8, 31, 3, 0, 0, 0, DateTimeKind.Utc), 5L, 1L, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_FuncionarioId",
                table: "Alocacoes",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alocacoes");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Notebooks");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
