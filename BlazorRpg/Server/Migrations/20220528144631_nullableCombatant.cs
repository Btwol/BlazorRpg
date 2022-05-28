using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorRpg.Server.Migrations
{
    public partial class nullableCombatant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentCombatants_Combatant_CombatantId",
                table: "CurrentCombatants");

            migrationBuilder.AlterColumn<int>(
                name: "CombatantId",
                table: "CurrentCombatants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentCombatants_Combatant_CombatantId",
                table: "CurrentCombatants",
                column: "CombatantId",
                principalTable: "Combatant",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentCombatants_Combatant_CombatantId",
                table: "CurrentCombatants");

            migrationBuilder.AlterColumn<int>(
                name: "CombatantId",
                table: "CurrentCombatants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentCombatants_Combatant_CombatantId",
                table: "CurrentCombatants",
                column: "CombatantId",
                principalTable: "Combatant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
