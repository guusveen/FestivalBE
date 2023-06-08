using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalBE.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraintForCouplingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_BezoekerId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_ArtiestFavorieten_BezoekerId",
                table: "ArtiestFavorieten");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BezoekerId_VoorstellingId",
                table: "Tickets",
                columns: new[] { "BezoekerId", "VoorstellingId" },
                unique: true,
                filter: "[BezoekerId] IS NOT NULL AND [VoorstellingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ArtiestFavorieten_BezoekerId_ArtiestId",
                table: "ArtiestFavorieten",
                columns: new[] { "BezoekerId", "ArtiestId" },
                unique: true,
                filter: "[BezoekerId] IS NOT NULL AND [ArtiestId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_BezoekerId_VoorstellingId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_ArtiestFavorieten_BezoekerId_ArtiestId",
                table: "ArtiestFavorieten");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BezoekerId",
                table: "Tickets",
                column: "BezoekerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtiestFavorieten_BezoekerId",
                table: "ArtiestFavorieten",
                column: "BezoekerId");
        }
    }
}
