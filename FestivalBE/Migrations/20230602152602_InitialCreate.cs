using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalBE.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artiesten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Afbeelding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artiesten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bezoekers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bezoekers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locaties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locaties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organisators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtiestFavorieten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BezoekerId = table.Column<int>(type: "int", nullable: true),
                    ArtiestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtiestFavorieten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtiestFavorieten_Artiesten_ArtiestId",
                        column: x => x.ArtiestId,
                        principalTable: "Artiesten",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArtiestFavorieten_Bezoekers_BezoekerId",
                        column: x => x.BezoekerId,
                        principalTable: "Bezoekers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Zalen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capaciteit = table.Column<int>(type: "int", nullable: true),
                    LocatieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zalen_Locaties_LocatieId",
                        column: x => x.LocatieId,
                        principalTable: "Locaties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerAfbeelding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeeftijdscategorieVan = table.Column<int>(type: "int", nullable: true),
                    LeeftijdscategorieTot = table.Column<int>(type: "int", nullable: true),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganisatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Festivals_Organisators_OrganisatorId",
                        column: x => x.OrganisatorId,
                        principalTable: "Organisators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FestivalLocatie",
                columns: table => new
                {
                    FestivalsId = table.Column<int>(type: "int", nullable: false),
                    LocatiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalLocatie", x => new { x.FestivalsId, x.LocatiesId });
                    table.ForeignKey(
                        name: "FK_FestivalLocatie_Festivals_FestivalsId",
                        column: x => x.FestivalsId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FestivalLocatie_Locaties_LocatiesId",
                        column: x => x.LocatiesId,
                        principalTable: "Locaties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voorstellingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Afbeelding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTijd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EindTijd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ZaalId = table.Column<int>(type: "int", nullable: true),
                    ArtiestId = table.Column<int>(type: "int", nullable: true),
                    FestivalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voorstellingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voorstellingen_Artiesten_ArtiestId",
                        column: x => x.ArtiestId,
                        principalTable: "Artiesten",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voorstellingen_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voorstellingen_Zalen_ZaalId",
                        column: x => x.ZaalId,
                        principalTable: "Zalen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BezoekerId = table.Column<int>(type: "int", nullable: true),
                    VoorstellingId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    Opmerking = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Bezoekers_BezoekerId",
                        column: x => x.BezoekerId,
                        principalTable: "Bezoekers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Voorstellingen_VoorstellingId",
                        column: x => x.VoorstellingId,
                        principalTable: "Voorstellingen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BezoekerId = table.Column<int>(type: "int", nullable: true),
                    VoorstellingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Bezoekers_BezoekerId",
                        column: x => x.BezoekerId,
                        principalTable: "Bezoekers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Voorstellingen_VoorstellingId",
                        column: x => x.VoorstellingId,
                        principalTable: "Voorstellingen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VoorstellingFavorieten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BezoekerId = table.Column<int>(type: "int", nullable: true),
                    VoorstellingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoorstellingFavorieten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoorstellingFavorieten_Bezoekers_BezoekerId",
                        column: x => x.BezoekerId,
                        principalTable: "Bezoekers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VoorstellingFavorieten_Voorstellingen_VoorstellingId",
                        column: x => x.VoorstellingId,
                        principalTable: "Voorstellingen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtiestFavorieten_ArtiestId",
                table: "ArtiestFavorieten",
                column: "ArtiestId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtiestFavorieten_BezoekerId",
                table: "ArtiestFavorieten",
                column: "BezoekerId");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalLocatie_LocatiesId",
                table: "FestivalLocatie",
                column: "LocatiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Festivals_OrganisatorId",
                table: "Festivals",
                column: "OrganisatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BezoekerId",
                table: "Ratings",
                column: "BezoekerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_VoorstellingId",
                table: "Ratings",
                column: "VoorstellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BezoekerId",
                table: "Tickets",
                column: "BezoekerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_VoorstellingId",
                table: "Tickets",
                column: "VoorstellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Voorstellingen_ArtiestId",
                table: "Voorstellingen",
                column: "ArtiestId");

            migrationBuilder.CreateIndex(
                name: "IX_Voorstellingen_FestivalId",
                table: "Voorstellingen",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Voorstellingen_ZaalId",
                table: "Voorstellingen",
                column: "ZaalId");

            migrationBuilder.CreateIndex(
                name: "IX_VoorstellingFavorieten_BezoekerId",
                table: "VoorstellingFavorieten",
                column: "BezoekerId");

            migrationBuilder.CreateIndex(
                name: "IX_VoorstellingFavorieten_VoorstellingId",
                table: "VoorstellingFavorieten",
                column: "VoorstellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Zalen_LocatieId",
                table: "Zalen",
                column: "LocatieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtiestFavorieten");

            migrationBuilder.DropTable(
                name: "FestivalLocatie");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "VoorstellingFavorieten");

            migrationBuilder.DropTable(
                name: "Bezoekers");

            migrationBuilder.DropTable(
                name: "Voorstellingen");

            migrationBuilder.DropTable(
                name: "Artiesten");

            migrationBuilder.DropTable(
                name: "Festivals");

            migrationBuilder.DropTable(
                name: "Zalen");

            migrationBuilder.DropTable(
                name: "Organisators");

            migrationBuilder.DropTable(
                name: "Locaties");
        }
    }
}
