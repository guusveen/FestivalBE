using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalBE.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordToBezoekerAndOrganisator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Organisators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Organisators",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Bezoekers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Organisators");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Organisators");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Bezoekers");
        }
    }
}
