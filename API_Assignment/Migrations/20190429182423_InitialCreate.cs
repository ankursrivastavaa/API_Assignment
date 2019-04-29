using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Assignment.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isEnabled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iexId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "Divident",
                columns: table => new
                {
                    Exe_date = table.Column<DateTime>(nullable: false),
                    Pay_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rec_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Dividends_type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divident", x => x.Exe_date);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    mic = table.Column<string>(nullable: false),
                    venue_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    volume = table.Column<double>(type: "float", nullable: false),
                    tapeA = table.Column<double>(type: "float", nullable: false),
                    tapeB = table.Column<double>(type: "float", nullable: false),
                    tapeC = table.Column<double>(type: "float", nullable: false),
                    market_percent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.mic);
                });

            migrationBuilder.CreateTable(
                name: "Previous",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    datetime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    open = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    high = table.Column<double>(type: "float", nullable: false),
                    low = table.Column<double>(type: "float", nullable: false),
                    close = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Previous", x => x.symbol);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Divident");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "Previous");
        }
    }
}
