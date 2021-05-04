using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopAtlanticoWebApi.Migrations
{
    public partial class petowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetsOwner_PetOwnerId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetOwnerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetOwnerId",
                table: "Pets");

            migrationBuilder.CreateTable(
                name: "PetPetOwner",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false),
                    PetOwnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetPetOwner", x => new { x.PetId, x.PetOwnersId });
                    table.ForeignKey(
                        name: "FK_PetPetOwner_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetPetOwner_PetsOwner_PetOwnersId",
                        column: x => x.PetOwnersId,
                        principalTable: "PetsOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetPetOwner_PetOwnersId",
                table: "PetPetOwner",
                column: "PetOwnersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetPetOwner");

            migrationBuilder.AddColumn<int>(
                name: "PetOwnerId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetOwnerId",
                table: "Pets",
                column: "PetOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetsOwner_PetOwnerId",
                table: "Pets",
                column: "PetOwnerId",
                principalTable: "PetsOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
