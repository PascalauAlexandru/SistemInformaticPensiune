using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemInformaticPensiune.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRezervareField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateInceput",
                table: "Rezervare",
                newName: "DataInceput");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataInceput",
                table: "Rezervare",
                newName: "DateInceput");
        }
    }
}
