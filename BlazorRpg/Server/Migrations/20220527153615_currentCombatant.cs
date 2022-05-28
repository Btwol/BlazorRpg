using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorRpg.Server.Migrations
{
    public partial class currentCombatant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Combatant");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Combatant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Combatant",
                table: "Combatant",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CurrentCombatants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPlayer = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CurrentHP = table.Column<long>(type: "bigint", nullable: false),
                    CombatantId = table.Column<int>(type: "int", nullable: false),
                    EncounterId = table.Column<int>(type: "int", nullable: true),
                    Initiative = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentCombatants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentCombatants_Combatant_CombatantId",
                        column: x => x.CombatantId,
                        principalTable: "Combatant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentCombatants_CombatantId",
                table: "CurrentCombatants",
                column: "CombatantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentCombatants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Combatant",
                table: "Combatant");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Combatant");

            migrationBuilder.RenameTable(
                name: "Combatant",
                newName: "Characters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "Id");
        }
    }
}
