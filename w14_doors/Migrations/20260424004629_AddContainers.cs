using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w9_efcore_intro.Migrations
{
    /// <inheritdoc />
    public partial class AddContainers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Container",
                table: "Container");

            migrationBuilder.RenameTable(
                name: "Container",
                newName: "Containers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Containers",
                table: "Containers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Containers_EquipmentId",
                table: "Characters",
                column: "EquipmentId",
                principalTable: "Containers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Containers_InventoryId",
                table: "Characters",
                column: "InventoryId",
                principalTable: "Containers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Containers_ContainerId",
                table: "Items",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Containers_EquipmentId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Containers_InventoryId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Containers_ContainerId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Containers",
                table: "Containers");

            migrationBuilder.RenameTable(
                name: "Containers",
                newName: "Container");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Container",
                table: "Container",
                column: "Id");

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
    }
}
