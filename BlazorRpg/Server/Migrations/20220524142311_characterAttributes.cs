using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorRpg.Server.Migrations
{
    public partial class characterAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Agi",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Att",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Def",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "HP",
                table: "Characters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Int",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Luck",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "MP",
                table: "Characters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Str",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vit",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wis",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agi",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Att",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Def",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HP",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Int",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Luck",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MP",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Str",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Vit",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Wis",
                table: "Characters");
        }
    }
}
