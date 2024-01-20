using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_manager_webapplication.Migrations
{
    public partial class background_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Backgrounds",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "Backgrounds",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Forgotten Realms" },
                    { 2, "Greyhawk" },
                    { 3, "Spelljammer" },
                    { 4, "Ravenloft" },
                    { 5, "Dark Sun" },
                    { 6, "Planescape" },
                    { 7, "Dragonlance" },
                    { 8, "Eberron" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Backgrounds",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Backgrounds",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

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
        }
    }
}
