using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppRoles_AppRoleId",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "FileNames",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "AppRoleId",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 20, 59, 58, 70, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 6, 20, 59, 58, 70, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 5, 6, 20, 59, 58, 70, DateTimeKind.Local).AddTicks(165), "$2a$11$XhIbjX9tcJiW1UdLaKGRdOKVCl0qHfkf.uncwaY.fBEznu9K9pQHK" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppRoles_AppRoleId",
                table: "AppUsers",
                column: "AppRoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppRoles_AppRoleId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "FileNames",
                table: "Blogs");

            migrationBuilder.AlterColumn<int>(
                name: "AppRoleId",
                table: "AppUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppRoles_AppRoleId",
                table: "AppUsers",
                column: "AppRoleId",
                principalTable: "AppRoles",
                principalColumn: "Id");
        }
    }
}
