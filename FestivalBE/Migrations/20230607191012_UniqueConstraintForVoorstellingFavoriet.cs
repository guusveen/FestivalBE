using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalBE.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraintForVoorstellingFavoriet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VoorstellingFavorieten_BezoekerId",
                table: "VoorstellingFavorieten");

            migrationBuilder.CreateIndex(
                name: "IX_VoorstellingFavorieten_BezoekerId_VoorstellingId",
                table: "VoorstellingFavorieten",
                columns: new[] { "BezoekerId", "VoorstellingId" },
                unique: true,
                filter: "[BezoekerId] IS NOT NULL AND [VoorstellingId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VoorstellingFavorieten_BezoekerId_VoorstellingId",
                table: "VoorstellingFavorieten");

            migrationBuilder.CreateIndex(
                name: "IX_VoorstellingFavorieten_BezoekerId",
                table: "VoorstellingFavorieten",
                column: "BezoekerId");
        }
    }
}
