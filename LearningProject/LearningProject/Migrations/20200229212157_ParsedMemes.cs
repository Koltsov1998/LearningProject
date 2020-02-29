using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LearningProject.Migrations
{
    public partial class ParsedMemes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VkPosts");

            migrationBuilder.CreateTable(
                name: "ParsedMemes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(nullable: true),
                    VkPublicId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParsedMemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParsedMemes_VkPublics_VkPublicId",
                        column: x => x.VkPublicId,
                        principalTable: "VkPublics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParsedMemes_VkPublicId",
                table: "ParsedMemes",
                column: "VkPublicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParsedMemes");

            migrationBuilder.CreateTable(
                name: "VkPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: true),
                    VkPublicId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VkPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VkPosts_VkPublics_VkPublicId",
                        column: x => x.VkPublicId,
                        principalTable: "VkPublics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VkPosts_VkPublicId",
                table: "VkPosts",
                column: "VkPublicId");
        }
    }
}
