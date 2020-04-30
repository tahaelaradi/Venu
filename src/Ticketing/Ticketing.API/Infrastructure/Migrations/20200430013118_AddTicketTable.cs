using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Venu.Ticketing.API.Infrastructure.Migrations
{
    public partial class AddTicketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Seat",
                newName: "SeatId");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<string>(nullable: false),
                    SeatId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Seat",
                newName: "Id");
        }
    }
}
