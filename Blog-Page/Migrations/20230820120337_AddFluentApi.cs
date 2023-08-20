using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_Page.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryID",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writers_WriterID",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Writers",
                table: "Writers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Writers",
                newName: "Yazarlar");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Kategoriler");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Bloglar");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Yazarlar",
                newName: "Durum");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Yazarlar",
                newName: "Güncellenme Tarihi");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Yazarlar",
                newName: "Soyadı");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Yazarlar",
                newName: "Adı");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Yazarlar",
                newName: "Oluşturulma Tarihi");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Kategoriler",
                newName: "Durum");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Kategoriler",
                newName: "Güncellenme Tarihi");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Kategoriler",
                newName: "Oluşturulma Tarihi");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Kategoriler",
                newName: "Kategori Adı");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Bloglar",
                newName: "Başlık");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Bloglar",
                newName: "Durum");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Bloglar",
                newName: "Güncellenme Tarihi");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Bloglar",
                newName: "Açıklama");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Bloglar",
                newName: "Oluşturulma Tarihi");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Bloglar",
                newName: "İçerik");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_WriterID",
                table: "Bloglar",
                newName: "IX_Bloglar_WriterID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategoryID",
                table: "Bloglar",
                newName: "IX_Bloglar_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yazarlar",
                table: "Yazarlar",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bloglar",
                table: "Bloglar",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bloglar_Kategoriler_CategoryID",
                table: "Bloglar",
                column: "CategoryID",
                principalTable: "Kategoriler",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bloglar_Yazarlar_WriterID",
                table: "Bloglar",
                column: "WriterID",
                principalTable: "Yazarlar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bloglar_Kategoriler_CategoryID",
                table: "Bloglar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bloglar_Yazarlar_WriterID",
                table: "Bloglar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yazarlar",
                table: "Yazarlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bloglar",
                table: "Bloglar");

            migrationBuilder.RenameTable(
                name: "Yazarlar",
                newName: "Writers");

            migrationBuilder.RenameTable(
                name: "Kategoriler",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Bloglar",
                newName: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Soyadı",
                table: "Writers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Oluşturulma Tarihi",
                table: "Writers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Güncellenme Tarihi",
                table: "Writers",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Durum",
                table: "Writers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Adı",
                table: "Writers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Oluşturulma Tarihi",
                table: "Categories",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Kategori Adı",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Güncellenme Tarihi",
                table: "Categories",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Durum",
                table: "Categories",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "İçerik",
                table: "Blogs",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Oluşturulma Tarihi",
                table: "Blogs",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Güncellenme Tarihi",
                table: "Blogs",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Durum",
                table: "Blogs",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Başlık",
                table: "Blogs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Açıklama",
                table: "Blogs",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Bloglar_WriterID",
                table: "Blogs",
                newName: "IX_Blogs_WriterID");

            migrationBuilder.RenameIndex(
                name: "IX_Bloglar_CategoryID",
                table: "Blogs",
                newName: "IX_Blogs_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Writers",
                table: "Writers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryID",
                table: "Blogs",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writers_WriterID",
                table: "Blogs",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
