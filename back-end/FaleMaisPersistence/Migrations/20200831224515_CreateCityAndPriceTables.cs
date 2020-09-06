using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaleMaisPersistence.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class CreateCityAndPriceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    area_code = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 236, DateTimeKind.Local).AddTicks(2543)),
                    updated_at = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 241, DateTimeKind.Local).AddTicks(102)),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.area_code);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    from_area_code = table.Column<byte>(nullable: false),
                    to_area_code = table.Column<byte>(nullable: false),
                    price_per_minut = table.Column<float>(type: "real", nullable: false),
                    created_at = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 244, DateTimeKind.Local).AddTicks(2512)),
                    updated_at = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 244, DateTimeKind.Local).AddTicks(2820)),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Cities_from_area_code",
                        column: x => x.from_area_code,
                        principalTable: "Cities",
                        principalColumn: "area_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prices_Cities_to_area_code",
                        column: x => x.to_area_code,
                        principalTable: "Cities",
                        principalColumn: "area_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_from_area_code",
                table: "Prices",
                column: "from_area_code");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_to_area_code",
                table: "Prices",
                column: "to_area_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
