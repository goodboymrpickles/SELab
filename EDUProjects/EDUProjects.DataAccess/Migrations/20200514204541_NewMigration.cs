using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDUProjects.DataAccess.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Gradings_GradingId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_GradingId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "GradingId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Subject_Title",
                table: "Classes");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Gradings",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "SubjectTitle",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gradings_TeacherId",
                table: "Gradings",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gradings_Teachers_TeacherId",
                table: "Gradings",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gradings_Teachers_TeacherId",
                table: "Gradings");

            migrationBuilder.DropIndex(
                name: "IX_Gradings_TeacherId",
                table: "Gradings");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Gradings");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "LevelRequirement",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "PassGrade",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SubjectTitle",
                table: "Classes");

            migrationBuilder.AddColumn<Guid>(
                name: "GradingId",
                table: "Teachers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject_Title",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_GradingId",
                table: "Teachers",
                column: "GradingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Gradings_GradingId",
                table: "Teachers",
                column: "GradingId",
                principalTable: "Gradings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
