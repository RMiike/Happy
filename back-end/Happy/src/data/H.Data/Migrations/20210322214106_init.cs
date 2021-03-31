using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace H.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orphanage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    OpenOnWeekends = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orphanage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orphanage");
        }
    }
}
