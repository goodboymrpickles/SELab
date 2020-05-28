using Microsoft.EntityFrameworkCore.Migrations;

namespace EDUProjects.DataAccess.Migrations
{
    public partial class Testeeeeeeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LevelRequirement",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassGrade",
                table: "Classes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "LevelRequirement",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "PassGrade",
                table: "Classes");
        }
    }
}
