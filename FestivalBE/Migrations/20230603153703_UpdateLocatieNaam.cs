using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalBE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLocatieNaam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "Locaties",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naam",
                table: "Locaties");
        }
    }
}
