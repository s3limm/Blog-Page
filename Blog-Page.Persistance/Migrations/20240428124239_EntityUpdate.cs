using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class EntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileData",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 28, 15, 42, 38, 976, DateTimeKind.Local).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 28, 15, 42, 38, 976, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 4, 28, 15, 42, 38, 976, DateTimeKind.Local).AddTicks(9580), "$2a$11$ZOmVGyA.Dm.I3Sa2j1VjAuSgI4vpGEGXYDmPqHlgKbMt.1xwaFbXO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "Blogs",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 20, 13, 37, 41, 194, DateTimeKind.Local).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 20, 13, 37, 41, 194, DateTimeKind.Local).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 37, 41, 194, DateTimeKind.Local).AddTicks(4724), "$2a$11$dJ7PvFSo96xT9ZNTSaJtj.Pe/qBaGj9Lv5P0ci98aZzkvT3g3.mMy" });
        }
    }
}
