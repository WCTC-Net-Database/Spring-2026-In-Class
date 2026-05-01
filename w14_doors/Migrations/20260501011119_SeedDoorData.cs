using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w9_efcore_intro.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seeding the locked door between Library (7) and Lab (8)
            migrationBuilder.InsertData(
                table: "Doors",
                columns: new[] {
                    "Id",
                    "Name",
                    "IsLocked",
                    "IsTrapped",
                    "IsPickable",
                    "IsSecret",
                    "RequiredKeyId",
                    "RoomAId",
                    "RoomBId"
                },
                values: new object[] {
                    1,
                    "Heavy Iron Door",
                    true,   // IsLocked
                    false,  // IsTrapped
                    true,   // IsPickable
                    false,  // IsSecret
                    "LAB_KEY_001", // The string ID to check against Inventory
                    7,      // Library
                    8       // Lab
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}