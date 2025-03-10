﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmokeTestDataImport.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdToProjectId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "SmokeDefects",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "SmokeDefects");
        }
    }
}
