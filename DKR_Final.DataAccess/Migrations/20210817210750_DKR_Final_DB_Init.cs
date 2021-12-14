using Microsoft.EntityFrameworkCore.Migrations;

namespace DKR_Final.DataAccess.Migrations
{
    public partial class DKR_Final_DB_Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    teamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    managerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.teamID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    playerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    playerAge = table.Column<int>(type: "int", nullable: false),
                    teamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.playerID);
                    table.ForeignKey(
                        name: "FK_Players_Teams_teamId",
                        column: x => x.teamId,
                        principalTable: "Teams",
                        principalColumn: "teamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_teamId",
                table: "Players",
                column: "teamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
