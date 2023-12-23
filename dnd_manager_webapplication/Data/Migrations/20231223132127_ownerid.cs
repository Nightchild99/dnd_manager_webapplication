using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_manager_webapplication.Data.Migrations
{
    public partial class ownerid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Characters");
        }
    }
}
