using Microsoft.EntityFrameworkCore.Migrations;

namespace LightingSurvey.Data.Migrations
{
    public partial class MoreAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Respondent_Address_Latitude",
                table: "Responces",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Respondent_Address_Line1",
                table: "Responces",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Respondent_Address_Line2",
                table: "Responces",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Respondent_Address_Longitude",
                table: "Responces",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Respondent_Address_Town",
                table: "Responces",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Respondent_Address_Latitude",
                table: "Responces");

            migrationBuilder.DropColumn(
                name: "Respondent_Address_Line1",
                table: "Responces");

            migrationBuilder.DropColumn(
                name: "Respondent_Address_Line2",
                table: "Responces");

            migrationBuilder.DropColumn(
                name: "Respondent_Address_Longitude",
                table: "Responces");

            migrationBuilder.DropColumn(
                name: "Respondent_Address_Town",
                table: "Responces");
        }
    }
}
