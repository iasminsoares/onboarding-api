using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegraApi.Application.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoNomeColunaObrigatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Obrigatório",
                table: "Atividades",
                newName: "Obrigatorio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Obrigatorio",
                table: "Atividades",
                newName: "Obrigatório");
        }
    }
}
