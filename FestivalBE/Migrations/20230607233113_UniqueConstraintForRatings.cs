using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalBE.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraintForRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ratings_BezoekerId",
                table: "Ratings");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BezoekerId_VoorstellingId",
                table: "Ratings",
                columns: new[] { "BezoekerId", "VoorstellingId" },
                unique: true,
                filter: "[BezoekerId] IS NOT NULL AND [VoorstellingId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ratings_BezoekerId_VoorstellingId",
                table: "Ratings");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BezoekerId",
                table: "Ratings",
                column: "BezoekerId");
        }
    }
}
