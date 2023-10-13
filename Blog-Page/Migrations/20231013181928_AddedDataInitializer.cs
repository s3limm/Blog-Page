using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataInitializer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedDate", "Email", "ModifiedDate", "Password", "Role", "Status", "userName" },
                values: new object[] { 1, new DateTime(2023, 10, 13, 21, 19, 28, 440, DateTimeKind.Local).AddTicks(8652), "selimemrem@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$10$7OVvK3IHup9maHk9y1ZGou35qqJPTFkvka2hKG3xdhuSBBA62A0hG", 0, 0, "s3limm" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
