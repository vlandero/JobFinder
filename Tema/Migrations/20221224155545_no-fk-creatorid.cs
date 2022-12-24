using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tema.Migrations
{
    /// <inheritdoc />
    public partial class nofkcreatorid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Seekers_CreatorId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CreatorId",
                table: "Companies");

            migrationBuilder.AddColumn<bool>(
                name: "IsCreator",
                table: "Seekers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCreator",
                table: "Seekers");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatorId",
                table: "Companies",
                column: "CreatorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Seekers_CreatorId",
                table: "Companies",
                column: "CreatorId",
                principalTable: "Seekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
