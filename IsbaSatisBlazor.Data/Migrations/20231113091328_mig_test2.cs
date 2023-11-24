using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsbaSatisBlazor.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PageEnd",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PageStart",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "PageEnd",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "PageStart",
                table: "Tests");
        }
    }
}
