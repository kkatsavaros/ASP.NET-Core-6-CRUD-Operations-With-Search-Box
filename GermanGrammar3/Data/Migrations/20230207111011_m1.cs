using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GermanGrammar3.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllTogether",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    german = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    english = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    greek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type1De = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type1En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type1Gr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type2De = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type2En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type2Gr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkDescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkDescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkDescriptionGr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllTogether", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllTogether");
        }
    }
}
