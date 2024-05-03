using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 2, 20, 1, 29, 267, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 2, 20, 1, 29, 267, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 5, 2, 20, 1, 29, 267, DateTimeKind.Local).AddTicks(7945), "$2a$11$TTMbiERvsI5sKisceYP.q.4Nd85T2eXuZgBp/33rUVVIce.4fI/.." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 2, 20, 0, 2, 231, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 2, 20, 0, 2, 231, DateTimeKind.Local).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 5, 2, 20, 0, 2, 231, DateTimeKind.Local).AddTicks(1131), "$2a$11$y.2.jjCPUiWsZTDX2RdhcO1afu0zZaYdYZuoraDWku9K/7cJ/U4Ju" });
        }
    }
}
