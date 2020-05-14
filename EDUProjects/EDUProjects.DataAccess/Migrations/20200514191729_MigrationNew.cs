using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDUProjects.DataAccess.Migrations
{
    public partial class MigrationNew : Migration
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

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Gradings",
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

            migrationBuilder.AddColumn<Guid>(
                name: "GradingId",
                table: "Teachers",
                type: "uniqueidentifier",
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
