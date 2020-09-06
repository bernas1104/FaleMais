using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaleMaisPersistence.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class FixePricePrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Calls",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 4, 16, 50, 13, 213, DateTimeKind.Local).AddTicks(7561),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 567, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.AlterColumn<decimal>(
                name: "price_per_minute",
                table: "Calls",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Calls",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 4, 16, 50, 13, 213, DateTimeKind.Local).AddTicks(7216),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 567, DateTimeKind.Local).AddTicks(2170));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "AreaCodes",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 4, 16, 50, 13, 209, DateTimeKind.Local).AddTicks(6041),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 561, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "AreaCodes",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 4, 16, 50, 13, 204, DateTimeKind.Local).AddTicks(4442),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 554, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)68, (byte)82 },
                column: "price_per_minute",
                value: 1.90m);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)68, (byte)96 },
                column: "price_per_minute",
                value: 1.70m);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)82, (byte)68 },
                column: "price_per_minute",
                value: 2.90m);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)82, (byte)96 },
                column: "price_per_minute",
                value: 0.90m);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)96, (byte)68 },
                column: "price_per_minute",
                value: 2.70m);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)96, (byte)82 },
                column: "price_per_minute",
                value: 1.90m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "Calls",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 567, DateTimeKind.Local).AddTicks(2578),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 4, 16, 50, 13, 213, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.AlterColumn<float>(
                name: "price_per_minute",
                table: "Calls",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Calls",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 567, DateTimeKind.Local).AddTicks(2170),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 4, 16, 50, 13, 213, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "AreaCodes",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 561, DateTimeKind.Local).AddTicks(5855),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 4, 16, 50, 13, 209, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "AreaCodes",
                type: "timestamp without time zone",
                nullable: true,
                defaultValue: new DateTime(2020, 9, 2, 15, 18, 11, 554, DateTimeKind.Local).AddTicks(4776),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 9, 4, 16, 50, 13, 204, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)68, (byte)82 },
                column: "price_per_minute",
                value: 1.9f);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)68, (byte)96 },
                column: "price_per_minute",
                value: 1.7f);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)82, (byte)68 },
                column: "price_per_minute",
                value: 2.9f);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)82, (byte)96 },
                column: "price_per_minute",
                value: 0.9f);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)96, (byte)68 },
                column: "price_per_minute",
                value: 2.7f);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumns: new[] { "from_area_code", "to_area_code" },
                keyValues: new object[] { (byte)96, (byte)82 },
                column: "price_per_minute",
                value: 1.9f);
        }
    }
}
