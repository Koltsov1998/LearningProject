using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningProject.Migrations
{
    public partial class ChangedVkPublicsClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uri",
                table: "VkPublics");

            migrationBuilder.AddColumn<string>(
                name: "Descritption",
                table: "VkPublics",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "VkPublics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsAdvertiser",
                table: "VkPublics",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "VkPublics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMember",
                table: "VkPublics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "VkPublics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo100",
                table: "VkPublics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo200",
                table: "VkPublics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo50",
                table: "VkPublics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScreenName",
                table: "VkPublics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "VkPublics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "VkPublics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VkId",
                table: "VkPublics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descritption",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "IsAdvertiser",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "IsMember",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "Photo100",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "Photo200",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "Photo50",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "ScreenName",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "VkPublics");

            migrationBuilder.DropColumn(
                name: "VkId",
                table: "VkPublics");

            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "VkPublics",
                type: "text",
                nullable: true);
        }
    }
}
