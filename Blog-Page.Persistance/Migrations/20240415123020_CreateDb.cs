using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 15, 15, 30, 20, 671, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 15, 15, 30, 20, 671, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 4, 15, 15, 30, 20, 671, DateTimeKind.Local).AddTicks(120), "$2a$11$U5a4vA6tjhQ5rTaOiueoBeDRX3mLdLU.LMCvCUKtTm4gyJZUQaUKK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 20, 15, 52, 33, 283, DateTimeKind.Local).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 20, 15, 52, 33, 283, DateTimeKind.Local).AddTicks(9506));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 3, 20, 15, 52, 33, 283, DateTimeKind.Local).AddTicks(8845), "$2a$11$2JE9xNl4x1IcFyy8/NSdzeFUUnieDFwdn7KKR1/4xfNc749vaUMBC" });
        }
    }
}
