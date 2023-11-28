﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.API.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangedBlogEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "Blogs",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Blogs");
        }
    }
}
