using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrupoA.Academic.Infra.Data.Migrations
{
    public partial class AjustesNomesCpfRa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RA",
                table: "Student",
                newName: "Ra");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Student",
                newName: "Cpf");

            migrationBuilder.RenameIndex(
                name: "IX_Student_RA",
                table: "Student",
                newName: "IX_Student_Ra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ra",
                table: "Student",
                newName: "RA");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Student",
                newName: "CPF");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Ra",
                table: "Student",
                newName: "IX_Student_RA");
        }
    }
}
