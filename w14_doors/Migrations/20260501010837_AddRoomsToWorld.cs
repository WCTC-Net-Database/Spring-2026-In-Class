using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w9_efcore_intro.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomsToWorld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // STAGE 1: Insert the new rooms with NO connections (nulls)
            // This ensures the IDs (6, 7, 8) exist before we try to link them.

            migrationBuilder.InsertData(
                table: "Containers",
                columns: new[] { "Id", "ContainerType", "MaxWeight", "IsLocked", "Name", "Description" },
                values: new object[] { 6, "Room", 9999, false, "Ancient Hallway", "A long corridor with flickering torches." });

            migrationBuilder.InsertData(
                table: "Containers",
                columns: new[] { "Id", "ContainerType", "MaxWeight", "IsLocked", "Name", "Description" },
                values: new object[] { 7, "Room", 9999, false, "Dusty Library", "Shelves of rotting books line the walls." });

            migrationBuilder.InsertData(
                table: "Containers",
                columns: new[] { "Id", "ContainerType", "MaxWeight", "IsLocked", "Name", "Description" },
                values: new object[] { 8, "Room", 9999, false, "Alchemist Lab", "Vials of glowing liquid bubble on stone tables." });

            // STAGE 2: Perform the connections now that all IDs exist

            // Link Bridge (5) -> Hallway (6)
            migrationBuilder.UpdateData(table: "Containers", keyColumn: "Id", keyValue: 5, column: "EastRoomId", value: 6);

            // Link Hallway (6) <-> Library (7)
            migrationBuilder.UpdateData(table: "Containers", keyColumn: "Id", keyValue: 6, column: "WestRoomId", value: 5);
            migrationBuilder.UpdateData(table: "Containers", keyColumn: "Id", keyValue: 6, column: "EastRoomId", value: 7);

            // Link Library (7) <-> Hallway (6) and Library -> Lab (8)
            migrationBuilder.UpdateData(table: "Containers", keyColumn: "Id", keyValue: 7, column: "WestRoomId", value: 6);
            migrationBuilder.UpdateData(table: "Containers", keyColumn: "Id", keyValue: 7, column: "NorthRoomId", value: 8);

            // Link Lab (8) -> Library (7)
            migrationBuilder.UpdateData(table: "Containers", keyColumn: "Id", keyValue: 8, column: "SouthRoomId", value: 7);
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reset Room 5's East exit
            migrationBuilder.UpdateData(
                table: "Containers",
                keyColumn: "Id",
                keyValue: 5,
                column: "EastRoomId",
                value: null);

            // Delete the new rooms in reverse order
            migrationBuilder.DeleteData(table: "Containers", keyColumn: "Id", keyValue: 8);
            migrationBuilder.DeleteData(table: "Containers", keyColumn: "Id", keyValue: 7);
            migrationBuilder.DeleteData(table: "Containers", keyColumn: "Id", keyValue: 6);
        }
    }
}