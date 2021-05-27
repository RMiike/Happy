using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace H.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orphanage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    OpeningHours = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    OpenOnWeekends = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orphanage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    OrphanageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Orphanage_OrphanageId",
                        column: x => x.OrphanageId,
                        principalTable: "Orphanage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_OrphanageId",
                table: "Image",
                column: "OrphanageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Orphanage");
        }
    }
}
