using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tema.Migrations
{
    /// <inheritdoc />
    public partial class cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Finders_FinderId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Seekers_SeekerId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Seekers_Companies_CompanyId",
                table: "Seekers");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Finders_FinderId",
                table: "Applicants",
                column: "FinderId",
                principalTable: "Finders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Seekers_SeekerId",
                table: "Jobs",
                column: "SeekerId",
                principalTable: "Seekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seekers_Companies_CompanyId",
                table: "Seekers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Finders_FinderId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Seekers_SeekerId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Seekers_Companies_CompanyId",
                table: "Seekers");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Finders_FinderId",
                table: "Applicants",
                column: "FinderId",
                principalTable: "Finders",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Seekers_SeekerId",
                table: "Jobs",
                column: "SeekerId",
                principalTable: "Seekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Seekers_Companies_CompanyId",
                table: "Seekers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
