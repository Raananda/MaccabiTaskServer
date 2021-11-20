using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerTemplateSlim.Migrations
{
    public partial class VideosModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VideoLinks",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaccabiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoLinks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VideoLinks_AspNetUsers_MaccabiUserId",
                        column: x => x.MaccabiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VideoLinks_VideoCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "VideoCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoLinks_CategoryID",
                table: "VideoLinks",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoLinks_MaccabiUserId",
                table: "VideoLinks",
                column: "MaccabiUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoLinks");

            migrationBuilder.DropTable(
                name: "VideoCategories");
        }
    }
}
