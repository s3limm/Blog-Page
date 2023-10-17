using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.Migrations
{
    /// <inheritdoc />
    public partial class AddedBlogImageDataProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogImageData",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 15, 8, 59, 29, 71, DateTimeKind.Local).AddTicks(35), "$2a$10$i.5ApLVH0WkOEXuAnYLVH.HZJHV84KKKo6IhPnYsGJvEZHkJ7TJDm" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogImageData",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 10, 15, 8, 57, 36, 756, DateTimeKind.Local).AddTicks(3768), "$2a$10$VLDODjioT1s/DJgNP6IuuO9hG.4JaEmNfNNXNDW/3rbVE3KagufS." });
        }
    }
}
