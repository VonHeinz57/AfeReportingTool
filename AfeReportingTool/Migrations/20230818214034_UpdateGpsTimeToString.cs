using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmokeTestDataImport.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGpsTimeToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GpsTime",
                table: "SmokeDefects",
                type: "text",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "GpsTime",
                table: "SmokeDefects",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
