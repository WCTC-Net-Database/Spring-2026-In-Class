using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w9_efcore_intro.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipmentItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EligibleSlot",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EquipmentSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    slotType = table.Column<int>(type: "int", nullable: false),
                    EquippedItemId = table.Column<int>(type: "int", nullable: true),
                    EquipmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentSlots_Containers_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Containers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentSlots_Items_EquippedItemId",
                        column: x => x.EquippedItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentSlots_EquipmentId",
                table: "EquipmentSlots",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentSlots_EquippedItemId",
                table: "EquipmentSlots",
                column: "EquippedItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentSlots");

            migrationBuilder.DropColumn(
                name: "EligibleSlot",
                table: "Items");
        }
    }
}
