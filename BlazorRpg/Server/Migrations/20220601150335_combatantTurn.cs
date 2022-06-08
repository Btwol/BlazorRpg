using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorRpg.Server.Migrations
{
    public partial class combatantTurn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Turn",
                table: "CurrentCombatants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Turn",
                table: "CurrentCombatants");
        }
    }
}
