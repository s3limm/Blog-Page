using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.API.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedBlogEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File",
                table: "Blogs",
                newName: "FileData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileData",
                table: "Blogs",
                newName: "File");
        }
    }
}
