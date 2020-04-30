using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Venu.Ticketing.API.Infrastructure.Migrations
{
    public partial class AddSeatAndVenueSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VenueSectionId = table.Column<string>(nullable: true),
                    Row = table.Column<int>(nullable: false),
                    Column = table.Column<int>(nullable: false),
                    IsOccupied = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                });

            migrationBuilder.CreateTable(
                name: "VenueSection",
                columns: table => new
                {
                    VenueSectionId = table.Column<string>(nullable: false),
                    VenueId = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueSection", x => x.VenueSectionId);
                    table.ForeignKey(
                        name: "FK_VenueSection_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VenueSection_EventId",
                table: "VenueSection",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "VenueSection");
        }
    }
}
