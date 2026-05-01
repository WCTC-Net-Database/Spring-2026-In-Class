using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w9_efcore_intro.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomContainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Rooms_HomeRoomId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Rooms_RoomId",
                table: "Monsters");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EastRoomId",
                table: "Containers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NorthRoomId",
                table: "Containers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SouthRoomId",
                table: "Containers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WestRoomId",
                table: "Containers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Containers_EastRoomId",
                table: "Containers",
                column: "EastRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_NorthRoomId",
                table: "Containers",
                column: "NorthRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_SouthRoomId",
                table: "Containers",
                column: "SouthRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_WestRoomId",
                table: "Containers",
                column: "WestRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Containers_HomeRoomId",
                table: "Characters",
                column: "HomeRoomId",
                principalTable: "Containers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Containers_EastRoomId",
                table: "Containers",
                column: "EastRoomId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Containers_NorthRoomId",
                table: "Containers",
                column: "NorthRoomId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Containers_SouthRoomId",
                table: "Containers",
                column: "SouthRoomId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Containers_WestRoomId",
                table: "Containers",
                column: "WestRoomId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Containers_RoomId",
                table: "Monsters",
                column: "RoomId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Containers_HomeRoomId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Containers_EastRoomId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Containers_NorthRoomId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Containers_SouthRoomId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Containers_WestRoomId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Containers_RoomId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Containers_EastRoomId",
                table: "Containers");

            migrationBuilder.DropIndex(
                name: "IX_Containers_NorthRoomId",
                table: "Containers");

            migrationBuilder.DropIndex(
                name: "IX_Containers_SouthRoomId",
                table: "Containers");

            migrationBuilder.DropIndex(
                name: "IX_Containers_WestRoomId",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "EastRoomId",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "NorthRoomId",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "SouthRoomId",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "WestRoomId",
                table: "Containers");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EastRoomId = table.Column<int>(type: "int", nullable: true),
                    NorthRoomId = table.Column<int>(type: "int", nullable: true),
                    SouthRoomId = table.Column<int>(type: "int", nullable: true),
                    WestRoomId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_EastRoomId",
                        column: x => x.EastRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_NorthRoomId",
                        column: x => x.NorthRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_SouthRoomId",
                        column: x => x.SouthRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Rooms_WestRoomId",
                        column: x => x.WestRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_EastRoomId",
                table: "Rooms",
                column: "EastRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_NorthRoomId",
                table: "Rooms",
                column: "NorthRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SouthRoomId",
                table: "Rooms",
                column: "SouthRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WestRoomId",
                table: "Rooms",
                column: "WestRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Rooms_HomeRoomId",
                table: "Characters",
                column: "HomeRoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Rooms_RoomId",
                table: "Monsters",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
