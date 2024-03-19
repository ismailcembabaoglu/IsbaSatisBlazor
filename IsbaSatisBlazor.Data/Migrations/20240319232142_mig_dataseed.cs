using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsbaSatisBlazor.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "CreatedUser", "Decription", "EMailAddress", "FirstName", "IsActive", "LastName", "Password", "UpdatedDate", "UpdatedUser" },
                values: new object[] { new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"), new DateTime(2024, 3, 19, 23, 21, 42, 213, DateTimeKind.Utc).AddTicks(9193), "Admin", null, "icb1742@gmail.com", "Süper", true, "Admin", "MTc0MjE3NDI=", null, null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreateDate", "CreatedUser", "Decription", "RoleType", "UpdatedDate", "UpdatedUser", "UserId" },
                values: new object[] { new Guid("065f9027-8f58-412c-a5a4-42fc3e80d15f"), new DateTime(2024, 3, 19, 23, 21, 42, 213, DateTimeKind.Utc).AddTicks(9617), "Admin", null, "Kullanıcı", null, null, new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("065f9027-8f58-412c-a5a4-42fc3e80d15f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"));
        }
    }
}
