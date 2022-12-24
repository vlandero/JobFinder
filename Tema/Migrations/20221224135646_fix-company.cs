using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tema.Migrations
{
    /// <inheritdoc />
    public partial class fixcompany : Migration
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

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Companies");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyCreatedId",
                table: "Seekers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seekers_CompanyCreatedId",
                table: "Seekers",
                column: "CompanyCreatedId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seekers_Companies_CompanyCreatedId",
                table: "Seekers",
                column: "CompanyCreatedId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seekers_Companies_CompanyCreatedId",
                table: "Seekers");

            migrationBuilder.DropIndex(
                name: "IX_Seekers_CompanyCreatedId",
                table: "Seekers");

            migrationBuilder.DropColumn(
                name: "CompanyCreatedId",
                table: "Seekers");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Companies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
