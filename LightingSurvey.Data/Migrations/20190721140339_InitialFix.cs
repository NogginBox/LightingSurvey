using Microsoft.EntityFrameworkCore.Migrations;

namespace LightingSurvey.Data.Migrations
{
    public partial class InitialFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyResponse",
                table: "SurveyResponse");

            migrationBuilder.RenameTable(
                name: "SurveyResponse",
                newName: "Responces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responces",
                table: "Responces",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responces",
                table: "Responces");

            migrationBuilder.RenameTable(
                name: "Responces",
                newName: "SurveyResponse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyResponse",
                table: "SurveyResponse",
                column: "Id");
        }
    }
}
