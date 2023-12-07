using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agraja.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PaymentTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Agros");

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Boxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Agros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
