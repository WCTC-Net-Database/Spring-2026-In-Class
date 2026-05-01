using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w9_efcore_intro.Migrations
{
    /// <inheritdoc />
    public partial class AddContainersItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterItem");

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContainerId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Defense",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EffectAmount",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EffectType",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Items",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Uses",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Items",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ContainerId",
                table: "Items",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EquipmentId",
                table: "Characters",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InventoryId",
                table: "Characters",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Container_EquipmentId",
                table: "Characters",
                column: "EquipmentId",
                principalTable: "Container",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Container_InventoryId",
                table: "Characters",
                column: "InventoryId",
                principalTable: "Container",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Container_ContainerId",
                table: "Items",
                column: "ContainerId",
                principalTable: "Container",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Container_EquipmentId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Container_InventoryId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Container_ContainerId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropIndex(
                name: "IX_Items_ContainerId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Characters_EquipmentId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_InventoryId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ContainerId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EffectAmount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EffectType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Uses",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Characters");

            migrationBuilder.CreateTable(
                name: "CharacterItem",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterItem", x => new { x.CharactersId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_CharacterItem_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterItem_ItemsId",
                table: "CharacterItem",
                column: "ItemsId");
        }
    }
}
