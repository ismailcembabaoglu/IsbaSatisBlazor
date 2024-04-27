using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsbaSatisBlazor.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_Addresstableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneAdressType",
                table: "Addreses",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("065f9027-8f58-412c-a5a4-42fc3e80d15f"),
                column: "CreateDate",
                value: new DateTime(2024, 4, 1, 23, 36, 8, 955, DateTimeKind.Utc).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 4, 1, 23, 36, 8, 955, DateTimeKind.Utc).AddTicks(7347));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneAdressType",
                table: "Addreses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("065f9027-8f58-412c-a5a4-42fc3e80d15f"),
                column: "CreateDate",
                value: new DateTime(2024, 4, 1, 0, 17, 50, 435, DateTimeKind.Utc).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 4, 1, 0, 17, 50, 435, DateTimeKind.Utc).AddTicks(5321));
        }
    }
}
