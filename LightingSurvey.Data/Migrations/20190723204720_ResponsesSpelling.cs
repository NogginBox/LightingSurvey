using Microsoft.EntityFrameworkCore.Migrations;

namespace LightingSurvey.Data.Migrations
{
    public partial class ResponsesSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responces",
                table: "Responces");

            migrationBuilder.RenameTable(
                name: "Responces",
                newName: "Responses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.RenameTable(
                name: "Responses",
                newName: "Responces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responces",
                table: "Responces",
                column: "Id");
        }
    }
}
