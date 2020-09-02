using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaleMaisPersistence.Migrations
{
    public partial class FixesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.CreateTable(
                name: "AreaCodes",
                columns: table => new
                {
                    area_code = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 554, DateTimeKind.Local).AddTicks(4776)),
                    updated_at = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 561, DateTimeKind.Local).AddTicks(5855)),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaCodes", x => x.area_code);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    from_area_code = table.Column<byte>(nullable: false),
                    to_area_code = table.Column<byte>(nullable: false),
                    price_per_minute = table.Column<float>(type: "real", nullable: false),
                    created_at = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 567, DateTimeKind.Local).AddTicks(2170)),
                    updated_at = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 567, DateTimeKind.Local).AddTicks(2578)),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => new { x.from_area_code, x.to_area_code });
                    table.ForeignKey(
                        name: "FK_Calls_AreaCodes_from_area_code",
                        column: x => x.from_area_code,
                        principalTable: "AreaCodes",
                        principalColumn: "area_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calls_AreaCodes_to_area_code",
                        column: x => x.to_area_code,
                        principalTable: "AreaCodes",
                        principalColumn: "area_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AreaCodes",
                columns: new[] { "area_code", "deleted_at", "name" },
                values: new object[,]
                {
                    { (byte)68, null, "Acre" },
                    { (byte)82, null, "Alagoas" },
                    { (byte)96, null, "Amapá" }
                });

            migrationBuilder.InsertData(
                table: "Calls",
                columns: new[] { "from_area_code", "to_area_code", "deleted_at", "price_per_minute" },
                values: new object[,]
                {
                    { (byte)68, (byte)82, null, 1.9f },
                    { (byte)82, (byte)68, null, 2.9f },
                    { (byte)68, (byte)96, null, 1.7f },
                    { (byte)96, (byte)68, null, 2.7f },
                    { (byte)82, (byte)96, null, 0.9f },
                    { (byte)96, (byte)82, null, 1.9f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calls_to_area_code",
                table: "Calls",
                column: "to_area_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "AreaCodes");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    area_code = table.Column<byte>(type: "smallint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2020, 9, 1, 18, 38, 7, 970, DateTimeKind.Local).AddTicks(218)),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2020, 9, 1, 18, 38, 7, 974, DateTimeKind.Local).AddTicks(6429))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.area_code);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2020, 9, 1, 18, 38, 7, 978, DateTimeKind.Local).AddTicks(584)),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    from_area_code = table.Column<byte>(type: "smallint", nullable: false),
                    price_per_minute = table.Column<float>(type: "real", nullable: false),
                    to_area_code = table.Column<byte>(type: "smallint", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2020, 9, 1, 18, 38, 7, 978, DateTimeKind.Local).AddTicks(983))
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
    }
}
