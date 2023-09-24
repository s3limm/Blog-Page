using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.Migrations
{
    /// <inheritdoc />
    public partial class AddedMultipyImageProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                table: "Blogs",
                newName: "image5");

            migrationBuilder.AddColumn<string>(
                name: "image1",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image2",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image3",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image4",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "image2",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "image3",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "image4",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "image5",
                table: "Blogs",
                newName: "image");
        }
    }
}
