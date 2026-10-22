using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KonyvtarWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class newDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Szerzok",
                columns: new[] { "Id", "Nev", "SzuletesiEv" },
                values: new object[,]
                {
                    { 1, "Kovács János", null },
                    { 2, "Nagy Péter", null }
                });

            migrationBuilder.InsertData(
                table: "Konyvek",
                columns: new[] { "Id", "Cim", "KiadasEve", "SzerzoId" },
                values: new object[,]
                {
                    { 1, "Példakönyv 1", 2020, 1 },
                    { 2, "Példakönyv 2", 2021, 2 },
                    { 3, "Példakönyv 3", 2022, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Konyvek",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Konyvek",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Konyvek",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Szerzok",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Szerzok",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
