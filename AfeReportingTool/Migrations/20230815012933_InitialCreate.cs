using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmokeTestDataImport.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmokeDefects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DefectTyp = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    SmokeRate = table.Column<string>(type: "text", nullable: false),
                    SurfaceCo = table.Column<string>(type: "text", nullable: false),
                    Grade = table.Column<string>(type: "text", nullable: false),
                    RunoffPot = table.Column<string>(type: "text", nullable: false),
                    DrainageA = table.Column<string>(type: "text", nullable: false),
                    AreaPhoto = table.Column<int>(type: "integer", nullable: false),
                    ZoomPhoto = table.Column<int>(type: "integer", nullable: false),
                    CrewLeade = table.Column<string>(type: "text", nullable: false),
                    GeneralCo = table.Column<string>(type: "text", nullable: true),
                    OffsetDis = table.Column<double>(type: "double precision", nullable: true),
                    OffsetBea = table.Column<double>(type: "double precision", nullable: true),
                    GeneralC2 = table.Column<string>(type: "text", nullable: true),
                    GeneralC3 = table.Column<string>(type: "text", nullable: true),
                    ExtraPhot = table.Column<int>(type: "integer", nullable: true),
                    ExtraPho2 = table.Column<int>(type: "integer", nullable: true),
                    ExtraPho3 = table.Column<int>(type: "integer", nullable: true),
                    UniqueId = table.Column<int>(type: "integer", nullable: false),
                    GpsDate = table.Column<DateOnly>(type: "date", nullable: false),
                    GpsTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    GnssHeigh = table.Column<float>(type: "real", nullable: false),
                    Northing = table.Column<float>(type: "real", nullable: false),
                    Easting = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmokeDefects", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmokeDefects");
        }
    }
}
