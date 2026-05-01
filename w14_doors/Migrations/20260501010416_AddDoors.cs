using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w9_efcore_intro.Migrations
{
    /// <inheritdoc />
    public partial class AddDoors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPickable",
                table: "Containers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSecret",
                table: "Containers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrapped",
                table: "Containers",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsTrapped = table.Column<bool>(type: "bit", nullable: false),
                    IsPickable = table.Column<bool>(type: "bit", nullable: false),
                    IsSecret = table.Column<bool>(type: "bit", nullable: false),
                    RequiredKeyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomAId = table.Column<int>(type: "int", nullable: false),
                    RoomBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doors_Containers_RoomAId",
                        column: x => x.RoomAId,
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doors_Containers_RoomBId",
                        column: x => x.RoomBId,
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doors_RoomAId",
                table: "Doors",
                column: "RoomAId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_RoomBId",
                table: "Doors",
                column: "RoomBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropColumn(
                name: "IsPickable",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "IsSecret",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "IsTrapped",
                table: "Containers");
        }
    }
}
