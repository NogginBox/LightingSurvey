using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightingSurvey.Data.Migrations
{
    public partial class ResponseDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Dates_Completed",
                table: "Responces",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates_Created",
                table: "Responces",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates_Modified",
                table: "Responces",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dates_Completed",
                table: "Responces");

            migrationBuilder.DropColumn(
                name: "Dates_Created",
                table: "Responces");

            migrationBuilder.DropColumn(
                name: "Dates_Modified",
                table: "Responces");
        }
    }
}
