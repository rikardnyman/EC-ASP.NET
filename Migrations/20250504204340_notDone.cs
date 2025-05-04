using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EC_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class notDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
