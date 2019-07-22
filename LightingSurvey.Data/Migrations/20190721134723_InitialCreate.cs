using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightingSurvey.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdExternal = table.Column<string>(nullable: true),
                    Respondent_Name = table.Column<string>(maxLength: 50, nullable: true),
                    Respondent_EmailAddress = table.Column<string>(maxLength: 254, nullable: true),
                    Respondent_Address_PostCode = table.Column<string>(maxLength: 9, nullable: true),
                    HappyWithLighting = table.Column<bool>(nullable: true),
                    PerceivedBrightnessLevel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponse", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyResponse");
        }
    }
}
