using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopAtlanticoWebApi.Migrations
{
    public partial class petDependency : Migration
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
                name: "IdPetOwner",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetOwnerId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "IdPet",
                table: "PetsOwner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "petId",
                table: "PetsOwner",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PetsOwner_petId",
                table: "PetsOwner",
                column: "petId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetsOwner_Pets_petId",
                table: "PetsOwner",
                column: "petId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetsOwner_Pets_petId",
                table: "PetsOwner");

            migrationBuilder.DropIndex(
                name: "IX_PetsOwner_petId",
                table: "PetsOwner");

            migrationBuilder.DropColumn(
                name: "IdPet",
                table: "PetsOwner");

            migrationBuilder.DropColumn(
                name: "petId",
                table: "PetsOwner");

            migrationBuilder.AddColumn<int>(
                name: "IdPetOwner",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PetOwnerId",
                table: "Pets",
                type: "int",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
