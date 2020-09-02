using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaleMaisPersistence.Migrations
{
    public partial class FixPriceColumnTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Cities_from_area_code",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Cities_to_area_code",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_from_area_code",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_to_area_code",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "price_per_minut",
                table: "Prices",
                newName: "price_per_minute");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Prices",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 1, 18, 27, 38, 667, DateTimeKind.Local).AddTicks(9847),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 244, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Prices",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 1, 18, 27, 38, 667, DateTimeKind.Local).AddTicks(9541),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 244, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.AddColumn<byte>(
                name: "FromCityAreaCode",
                table: "Prices",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "ToCityAreaCode",
                table: "Prices",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Cities",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 1, 18, 27, 38, 664, DateTimeKind.Local).AddTicks(8302),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 241, DateTimeKind.Local).AddTicks(102));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Cities",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 1, 18, 27, 38, 660, DateTimeKind.Local).AddTicks(2407),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 236, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.CreateIndex(
                name: "IX_Prices_FromCityAreaCode",
                table: "Prices",
                column: "FromCityAreaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ToCityAreaCode",
                table: "Prices",
                column: "ToCityAreaCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Cities_FromCityAreaCode",
                table: "Prices",
                column: "FromCityAreaCode",
                principalTable: "Cities",
                principalColumn: "area_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Cities_ToCityAreaCode",
                table: "Prices",
                column: "ToCityAreaCode",
                principalTable: "Cities",
                principalColumn: "area_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Cities_FromCityAreaCode",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Cities_ToCityAreaCode",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_FromCityAreaCode",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_ToCityAreaCode",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "FromCityAreaCode",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "ToCityAreaCode",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "price_per_minute",
                table: "Prices",
                newName: "price_per_minut");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Prices",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 244, DateTimeKind.Local).AddTicks(2820),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 1, 18, 27, 38, 667, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Prices",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 244, DateTimeKind.Local).AddTicks(2512),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 1, 18, 27, 38, 667, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Cities",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 241, DateTimeKind.Local).AddTicks(102),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 1, 18, 27, 38, 664, DateTimeKind.Local).AddTicks(8302));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Cities",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2020, 8, 31, 19, 45, 15, 236, DateTimeKind.Local).AddTicks(2543),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 1, 18, 27, 38, 660, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.CreateIndex(
                name: "IX_Prices_from_area_code",
                table: "Prices",
                column: "from_area_code");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_to_area_code",
                table: "Prices",
                column: "to_area_code");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Cities_from_area_code",
                table: "Prices",
                column: "from_area_code",
                principalTable: "Cities",
                principalColumn: "area_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Cities_to_area_code",
                table: "Prices",
                column: "to_area_code",
                principalTable: "Cities",
                principalColumn: "area_code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
