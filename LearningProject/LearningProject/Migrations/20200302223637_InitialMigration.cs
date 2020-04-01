using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LearningProject.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VkPublics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(nullable: true),
                    VkId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ScreenName = table.Column<string>(nullable: true),
                    IsClosed = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsMember = table.Column<bool>(nullable: false),
                    IsAdvertiser = table.Column<string>(nullable: true),
                    Descritption = table.Column<string>(nullable: true),
                    Photo50 = table.Column<string>(nullable: true),
                    Photo100 = table.Column<string>(nullable: true),
                    Photo200 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VkPublics", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "VkPublics");
        }
    }
}
