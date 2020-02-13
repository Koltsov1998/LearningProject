using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LearningProject.Migrations
{
    public partial class AddedVkPublics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VkPublicId",
                table: "VkPosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VkPublics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VkPublics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VkPosts_VkPublicId",
                table: "VkPosts",
                column: "VkPublicId");

            migrationBuilder.AddForeignKey(
                name: "FK_VkPosts_VkPublics_VkPublicId",
                table: "VkPosts",
                column: "VkPublicId",
                principalTable: "VkPublics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VkPosts_VkPublics_VkPublicId",
                table: "VkPosts");

            migrationBuilder.DropTable(
                name: "VkPublics");

            migrationBuilder.DropIndex(
                name: "IX_VkPosts_VkPublicId",
                table: "VkPosts");

            migrationBuilder.DropColumn(
                name: "VkPublicId",
                table: "VkPosts");
        }
    }
}
