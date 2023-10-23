using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospiten.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class audi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Patient",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Patient",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Patient");
        }
    }
}
