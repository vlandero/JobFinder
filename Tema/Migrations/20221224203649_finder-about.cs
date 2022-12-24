using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tema.Migrations
{
    /// <inheritdoc />
    public partial class finderabout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Finders",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Finders");
        }
    }
}
