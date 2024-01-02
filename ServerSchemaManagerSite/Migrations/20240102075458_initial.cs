using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerSchemaManagerSite.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SsmRegions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ShortName = table.Column<string>(type: "nchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SsmRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SsmUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ShortName = table.Column<string>(type: "nchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SsmUsages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SsmServers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostName = table.Column<string>(type: "nchar(16)", nullable: false),
                    IPv4_Internal = table.Column<byte[]>(type: "binary(4)", nullable: false),
                    IPv4 = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    IPv6_Internal = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    UsageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SsmServers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SsmServers_SsmRegions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "SsmRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SsmServers_SsmUsages_UsageId",
                        column: x => x.UsageId,
                        principalTable: "SsmUsages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SsmServers_RegionId",
                table: "SsmServers",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_SsmServers_UsageId",
                table: "SsmServers",
                column: "UsageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SsmServers");

            migrationBuilder.DropTable(
                name: "SsmRegions");

            migrationBuilder.DropTable(
                name: "SsmUsages");
        }
    }
}
