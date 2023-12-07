using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agraja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CRUD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prize",
                table: "Agros",
                newName: "Prize");

            migrationBuilder.AlterColumn<double>(
                name: "Kg",
                table: "Boxes",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prize",
                table: "Agros",
                newName: "prize");

            migrationBuilder.AlterColumn<int>(
                name: "Kg",
                table: "Boxes",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
