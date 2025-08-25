using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QtdLugares",
                table: "Salas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "FuncionarioIdFuncionario",
                table: "Alocacoes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_FuncionarioIdFuncionario",
                table: "Alocacoes",
                column: "FuncionarioIdFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Alocacoes_Funcionarios_FuncionarioIdFuncionario",
                table: "Alocacoes",
                column: "FuncionarioIdFuncionario",
                principalTable: "Funcionarios",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alocacoes_Funcionarios_FuncionarioIdFuncionario",
                table: "Alocacoes");

            migrationBuilder.DropIndex(
                name: "IX_Alocacoes_FuncionarioIdFuncionario",
                table: "Alocacoes");

            migrationBuilder.DropColumn(
                name: "QtdLugares",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "FuncionarioIdFuncionario",
                table: "Alocacoes");
        }
    }
}
