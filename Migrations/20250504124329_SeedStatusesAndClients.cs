using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EC_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class SeedStatusesAndClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientName" },
                values: new object[,]
                {
                    { "1", "Client 1" },
                    { "2", "Client 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
