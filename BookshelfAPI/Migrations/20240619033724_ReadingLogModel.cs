using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookshelfAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReadingLogModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LogDetails",
                table: "ReadingLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CurrentPage",
                table: "ReadingLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ReadingLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "ReadingLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ReadingLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPage",
                table: "ReadingLogs");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ReadingLogs");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ReadingLogs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ReadingLogs");

            migrationBuilder.AlterColumn<string>(
                name: "LogDetails",
                table: "ReadingLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
