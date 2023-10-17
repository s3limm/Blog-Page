using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedImageProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 15, 8, 54, 27, 639, DateTimeKind.Local).AddTicks(6474), "$2a$10$1vUsJI6SSTbPCWYeCKUIzeGyjSMWjetYSxgfFWnz.PWNyADvlq/iu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 15, 8, 49, 2, 804, DateTimeKind.Local).AddTicks(3564), "$2a$10$ylgz0zky2SeUF20ZnTSYnu4mNWmPIvoWwCaboDsRyBIq67aQN9D3W" });
        }
    }
}
