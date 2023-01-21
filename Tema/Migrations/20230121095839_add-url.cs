using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tema.Migrations
{
    /// <inheritdoc />
    public partial class addurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Seekers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Finders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Seekers_Url",
                table: "Seekers",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Finders_Url",
                table: "Finders",
                column: "Url",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seekers_Url",
                table: "Seekers");

            migrationBuilder.DropIndex(
                name: "IX_Finders_Url",
                table: "Finders");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Seekers");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Finders");
        }
    }
}
