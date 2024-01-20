using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_manager_webapplication.Migrations
{
    public partial class background : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BackgroundID",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Backgrounds",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backgrounds", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Backgrounds",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { -8, 1 },
                    { -7, 2 },
                    { -6, 5 },
                    { -5, 7 },
                    { -4, 4 },
                    { -3, 6 },
                    { -2, 3 },
                    { -1, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BackgroundID",
                table: "Characters",
                column: "BackgroundID");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Backgrounds_BackgroundID",
                table: "Characters",
                column: "BackgroundID",
                principalTable: "Backgrounds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Backgrounds_BackgroundID",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Backgrounds");

            migrationBuilder.DropIndex(
                name: "IX_Characters_BackgroundID",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "BackgroundID",
                table: "Characters");
        }
    }
}
